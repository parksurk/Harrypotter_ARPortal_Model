using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextController : MonoBehaviour
{
    private Animator textAnim;

    private bool textStartAni = false;

    private void Awake()
    {
        textAnim = gameObject.GetComponent<Animator>();
    }

    public void PlayAnimation()
    {
        if (!textStartAni)
        {
            textAnim.Play("Text1_StartAni", 0, 0.0f);
            textStartAni = true;
        }
        else
        {
            textAnim.Play("Text1_EndAni", 0, 0.0f);
            textStartAni = false;
        }
    }
}
