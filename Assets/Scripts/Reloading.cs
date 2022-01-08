using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Reloading : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("Reload", 1);      
    }

    void Reload()
    {
        SceneManager.LoadScene("SampleScene");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
