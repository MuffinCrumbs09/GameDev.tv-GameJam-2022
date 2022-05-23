using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    public Animator a;
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            a.SetTrigger("Open");
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            a.SetTrigger("Close");
        }
    }

    public void Open(){
        a.SetTrigger("Open");
    }

    public void Close(){
        a.SetTrigger("Close");
    }
}
