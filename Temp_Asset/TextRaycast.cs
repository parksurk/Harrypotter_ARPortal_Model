using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextRaycast : MonoBehaviour
{
    [SerializeField] private int rayLength = 5; //레이 길이
    [SerializeField] private LayerMask layerMaskInteract; //마스크 레이어
    [SerializeField] private string excludeLayerName = null; //

    private TextController raycastedObj; //TextController스크립트를 가지는 오브젝트

    [SerializeField] private KeyCode openDoorKey = KeyCode.Mouse0; //문을 움직일 키지정

    [SerializeField] private Image crosshair = null; //표적 표시 이미지
    private bool isCrosshairActive; // 표적 겨냥유무
    private bool doOnce; // 표적겨냥유무를 한번만 시행하기위해??

    private const string interactableTag = "InteractiveObject";  //태그확인

    private void Update()
    {
        RaycastHit hit;
        Vector3 fwd = transform.TransformDirection(Vector3.forward);  //레이방향 설정

        int mask = 1 << LayerMask.NameToLayer(excludeLayerName) | layerMaskInteract.value;  //??

        if (Physics.Raycast(transform.position, fwd, out hit, rayLength, mask)) // 레이가 앞방향으로 발사될때
        {
            if(hit.Collider.CompareTag(interactableTag))  //부딪힌오브젝트 태그를 비교해 interactableTag이면
            {
                if (!doOnce)  //doOnce가 거짓이면
                {
                    raycastedObj = hit.Collider.gameObject.GetComponent<TextController>(); //레이에맞은 오브젝트의 TextController를 가져옴
                    CrosshairChange(true);  //CrosshairChange메서드를 true로 실행(크로스헤어 색변경메서드)
                }

                isCrosshairActive = true; //겨냥 유무를 겨냥으로 바꿈
                doOnce = true;  //한번을 한걸로..

                if (Input.GetKeyDown(openDoorKey))  //openDoorKey에 설정한 키값(마우스왼쪽버튼)을 누르면
                {
                    raycastedObj.PlayAnimation();  //raycastedObj(레이를 맞은 오브젝트)에 애니메이션 메서드 실행 ->TextControoler에 있음
                }
            }
        }

        else  //그렇지 않으면
        {
            if (isCrosshairActive)  //겨냥 유무를 겨냥이면
            {
                CrosshairChange(false);  //CrosshairChange메서드를 false로 실행(크로스헤어 색변경메서드)
                doOnce = false; //한번에 한걸 안한걸로
            }
        }
    }

    void CrosshairChange(bool on)
    {
        if (on && !doOnce)
        {
            crosshair.color = Color.red;
        }
        else
        {
            crosshair.color = Color.white;
            isCrosshairActive = false;
        }
    }
}
