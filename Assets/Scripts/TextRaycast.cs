using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextRaycast : MonoBehaviour
{
    [SerializeField] private int rayLength = 30;
    //[SerializeField] private LayerMask layerMaskInteract;
    //[SerializeField] private string excludeLayerName = null;
    private TextController raycastedObj;
    private bool isCrosshairActive;
    private bool doOnce;
    //public string[] pictureTag = { "Picture1", "Picture2", "Picture3", "Picture4", "Picture5", "Picture6" };
    //int picIndex;
    private const string pictureTag = "Picture1";
    //public GameObject[] textObject = new GameObject[6];

    private void Update()
    {
        RaycastHit hit;
        Vector3 fwd = transform.TransformDirection(Vector3.forward);
        Debug.DrawRay(transform.position, fwd, Color.red);
        //int mask = 1 << LayerMask.NameToLayer(excludeLayerName) | layerMaskInteract.value;

        if (Physics.Raycast(transform.position, fwd, out hit, rayLength))
        {
            if (hit.collider.CompareTag(pictureTag))
            {
                if (!doOnce)
                {
                    raycastedObj = hit.collider.gameObject.GetComponent<TextController>();
                    CrosshairChange(true);
                    raycastedObj.PlayAnimation();
                    Debug.Log("Raycast Hit!!");

                    isCrosshairActive = true;
                    doOnce = true;
                }
            }
        }

        else
        {
            if (isCrosshairActive)
            {
                //raycastedObj.PlayEndAnimation();
                CrosshairChange(false);
                doOnce = false;
            }
        }
    }

    void CrosshairChange(bool on)
    {
        if (on && !doOnce)
        {
            isCrosshairActive = true;
        }
        else
        {
            isCrosshairActive = false;
        }
    }

    /*private Animator textAnim;

    private bool textStartAni;

    public Renderer[] textObjRenderer = new Renderer [6];

    private void Awake()
    {
        textAnim = gameObject.GetComponent<Animator>();
        textObject[picIndex].GetComponent<MeshRenderer>();
        for (picIndex = 0; picIndex < 5; picIndex++)
        {
            textObjRenderer[picIndex].enabled = false;
        }
    }

    public void PlayAnimation()
    {
        if (!textStartAni)
        {
            textObjRenderer[picIndex].enabled = true;

            if (pictureTag[picIndex] == "Picture1")
            {
                textAnim.Play("Text_StartAni", 0, 0.0f);
            }

            else if (pictureTag[picIndex] == "Picture2")
            {
                textAnim.Play("Text1_StartAni", 0, 0.0f);
            }

            else if (pictureTag[picIndex] == "Picture3")
            {
                textAnim.Play("Text2_StartAni", 0, 0.0f);
            }

            else if (pictureTag[picIndex] == "Picture4")
            {
                textAnim.Play("Text3_StartAni", 0, 0.0f);
            }

            else if (pictureTag[picIndex] == "Picture5")
            {
                textAnim.Play("Text4_StartAni", 0, 0.0f);
            }

            else if (pictureTag[picIndex] == "Picture6")
            {
                textAnim.Play("Text5_StartAni", 0, 0.0f);
            }

            textStartAni = true;
        }
    }*/
}
