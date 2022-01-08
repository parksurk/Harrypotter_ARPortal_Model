using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class Placement : MonoBehaviour
{
    public GameObject placementObject;

    //[SerializedField]
    //private ARSessionOrigin arSessionOrigin;
    public ARSessionOrigin arSessionOrigin;
    //[SerializedField]
    //private ARRaycastManager arRaycastManager;
    public ARRaycastManager arRaycastManager;

    private Pose placementPose;
    private bool placementPoseIsValid = false;
    //[SerializedField]
    TrackableType trackableType = TrackableType.Planes;

    // Update is called once per frame
    void Update()
    {
        UpdatePlacementPose();
        UpdatePlacementObject();
    }

    private void UpdatePlacementObject()
    {
        if (placementPoseIsValid)
        {
            placementObject.SetActive(true);
            placementObject.transform.SetPositionAndRotation(placementPose.position, placementPose.rotation);
        }
        else
        {
            placementObject.SetActive(false);
        }
    }

    private void UpdatePlacementPose()
    {
        var screenCenter = arSessionOrigin.camera.ViewportToScreenPoint(new Vector3(0.5f, 0.5f));
        var hits = new List<ARRaycastHit>();
        arRaycastManager.Raycast(screenCenter, hits, trackableType);

        placementPoseIsValid  = hits.Count > 0;
        if (placementPoseIsValid)
        {
            placementPose = hits[0].pose;

            var cameraForward = arSessionOrigin.camera.transform.forward;
            var cameraBearing = new Vector3(cameraForward.x, 0, cameraForward.z).normalized;
            placementPose.rotation = Quaternion.LookRotation(cameraBearing);
        }
    }
}
