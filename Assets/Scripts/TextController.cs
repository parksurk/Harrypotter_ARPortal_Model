using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextController : MonoBehaviour
{
    private Animator textAnim;

    private bool textStartAni;

    public Renderer textObj;

    private void Awake()
    {
        textAnim = gameObject.GetComponent<Animator>();
        gameObject.GetComponent<MeshRenderer>();
        textObj.enabled = false;
    }

    public void PlayAnimation()
    {
        if (!textStartAni)
        {
            textObj.enabled = true;
            textAnim.Play("Text_StartAni", 0, 0.0f);
            textStartAni = true;
        }
        else
        {
            //textAnim.Play("Text_EndAni", 0, 0.0f);
            textStartAni = false;
            textObj.enabled = false;
        }
    }

    /*public void PlayEndAnimation()
    {
        if (textStartAni)
        {
            textAnim.Play("Text_EndAni", 0, 0.0f);
            textStartAni = false;
            textObj.enabled = false;
        }
    }*/
}
