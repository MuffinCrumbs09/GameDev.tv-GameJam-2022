using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleTorch : MonoBehaviour
{
    public bool on;

    void Update()
    {
        if(Input.GetMouseButtonDown(0) && !on){
            GetComponent<Light>().enabled = true;
            on = true;
        } else if(Input.GetMouseButtonDown(0) && on){
            GetComponent<Light>().enabled = false;
            on = false;
        }
    }
}
