using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour
{
    bool inWater;

    int maxTime = 4;

    GameObject drownCam;
    float time; 

    void Start()
    {
        drownCam = GameObject.Find("Drown");
        drownCam.SetActive(false);
    }
    void OnTriggerStay(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            if(time >= maxTime && inWater){
                other.GetComponent<Health>().TakeHealth(100);
            }
        }
    }

    void Update()
    {
        time += 1 * Time.deltaTime;
    }

    void OnTriggerEnter(Collider other)
    {
        inWater = true;
        time = 0;
        
        drownCam.SetActive(true);
        drownCam.GetComponent<Animator>().SetTrigger("Drown");
    }
}
