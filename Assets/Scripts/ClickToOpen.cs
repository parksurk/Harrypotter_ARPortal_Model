using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickToOpen : MonoBehaviour
{
	public GameObject GateR;
	public GameObject GateL;
	public GameObject cI;
	public float angleR;
	public float angleL;
	public Vector3 direction;
	bool opening = false;

	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "MainCamera")
		{
			//Debug.Log("Entered Camera");
			opening = true;
		}
	}

	void OnTriggerExit(Collider other)
	{
		if (other.tag == "MainCamera")
		{
			//Debug.Log("Exit Camera");
			opening = false;
		}
	}

	void Start()
	{
		angleR = GateR.transform.eulerAngles.y;
		angleL = GateL.transform.eulerAngles.y;
	}

	void Update()
	{
		if (Mathf.Round(GateR.transform.eulerAngles.y) != angleR)
		{
			GateR.transform.Rotate(direction * 2);
		}

		if (Mathf.Round(GateL.transform.eulerAngles.y) != angleL)
		{
			GateL.transform.Rotate(-direction * 2);
		}

		if (opening == true)
		{
			angleR = 90	;
			angleL = 270;
			direction = Vector3.up;
			cI.SetActive(false);
		}
		else
		{
			angleR = 0;
			angleL = 0;
			direction = Vector3.down;
		}

		/*if (Input.GetKeyDown(KeyCode.O))
		{
			angleR = 270;
			angleL = 90;
			direction = Vector3.up;
		}*/

		/*if (Input.GetMouseButtonDown (0))
		{
			Ray toMouse = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit rhInfo;
			bool didHit = Physics.Raycast(toMouse, out rhInfo, 500.0f);
			if(didHit)
			{
				Debug.Log(rhInfo.collider.name + "--" + rhInfo.point);
			}
			else
			{
				Debug.Log("clicked on empty space");
			}
		}*/
	}
}
