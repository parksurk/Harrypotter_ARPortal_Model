using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExplainPics : MonoBehaviour
{

    public GameObject textPic;
    private bool textShape;
    private Animator textPlay;

    //private TextController raycastedObj;

    private void Awake()
    {
        textPlay = gameObject.GetComponent<Animator>();
    }

    void Start()
    {
        
    }

    void Update()
    {
        pointer();
    }

    public void pointer()
    {
        RaycastHit hit;
        Vector3 ray = transform.TransformDirection(Vector3.forward*300);
        //Physics.Raycast()
        if (!textShape)
        {

            if (Physics.Raycast(transform.position, ray, out hit))
            {
                if(hit.collider.tag == "Picture1")
                {
                    textPlay.Play("Text1_StartAni", 0, 0.0f);
                    //hit.transform.GetComponent<Animator>().Play("Text1_StartAni", 0, 0.0f);
                    Debug.Log("ray Hit!!");
                    //raycastedObj.PlayAnimation();
                }
            }
        }
        Debug.DrawRay(transform.position, ray, Color.red);
    }
}
