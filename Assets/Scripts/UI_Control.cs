using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UI_Control : MonoBehaviour
{

	//public GameObject portalBox;

  	public void PlayGame ()
		{
			//SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
			SceneManager.LoadScene("UpdateScene");
		}

	public void QuitGame ()
	{
		SceneManager.LoadScene("QuitScene");
	}
}
