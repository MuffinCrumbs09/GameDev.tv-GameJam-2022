using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lava : MonoBehaviour
{
    void OnTriggerStay(Collider other)
    {
        if(other.tag == "Player"){
            other.GetComponent<Health>().TakeHealth(100);
        }
    }
}
