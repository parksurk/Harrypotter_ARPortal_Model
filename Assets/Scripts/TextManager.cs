using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextManager : MonoBehaviour
{
    //[SerializeField] private string selectableTag = "Selectable";
    [SerializeField] private LayerMask layerMaskInteract;
    [SerializeField] private string excludeLayerName = null;
    //[SerializeField] private Material highlightMaterial;
    //[SerializeField] private Material defaultMaterial;

    private Transform _selection;

    void Update()
    {
        Vector3 fwd = transform.TransformDirection(Vector3.forward);
        Debug.DrawRay(transform.position, fwd, Color.red);
        if (_selection != null)
        {
            var selectionRenderer = _selection.GetComponent<MeshRenderer>();
            selectionRenderer.enabled = false;
            _selection = null;
        }
        //int mask = 1 << LayerMask.NameToLayer(excludeLayerName) | layerMaskInteract.value;
        var ray = Camera.main.ScreenPointToRay(fwd);
        RaycastHit hit;
        if (Physics.Raycast(transform.position, fwd, out hit, 30, layerMaskInteract))
        {
            var selection = hit.transform;
            var selectionRenderer = selection.GetComponent<MeshRenderer>();
            if (selectionRenderer != null)
            {
                selectionRenderer.enabled = true;
                Debug.Log("Raycast Hit!!");
            }

            _selection = selection;
        }
    }
}
