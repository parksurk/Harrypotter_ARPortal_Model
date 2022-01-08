using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PictureRaycast : MonoBehaviour
{
    RaycastHit hit;
    float MaxDistance = 15f;

    void Update ()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.position = new Vector3(transform.position.x + 0.1f, transform.position.y, transform.position.z);
        }
    }
}
