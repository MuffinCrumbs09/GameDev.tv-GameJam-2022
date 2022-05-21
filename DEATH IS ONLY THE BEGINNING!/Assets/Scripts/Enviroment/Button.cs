using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    public GameObject ObjectToChange;
    void OnTriggerEnter(Collider other)
    {
        Open();
    }

    void OnTriggerExit(Collider other)
    {
        Close();
    }


    void Open()
    {
        if (ObjectToChange.GetComponent<Animator>() != null)
        {
            ObjectToChange.GetComponent<Animator>().SetTrigger("Open");
        }
    }

        void Close()
    {
        if (ObjectToChange.GetComponent<Animator>() != null)
        {
            ObjectToChange.GetComponent<Animator>().SetTrigger("Close");
        }
    }
}
