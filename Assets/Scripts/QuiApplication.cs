using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuiApplication : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }    
    }
}
