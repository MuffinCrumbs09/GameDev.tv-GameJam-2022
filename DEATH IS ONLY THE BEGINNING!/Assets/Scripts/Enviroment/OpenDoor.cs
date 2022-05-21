using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    public Animator a;

    bool open;
    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            if (!open)
            {
                open = true;
                a.SetBool("OpenDoor", open);
            }

        }
    }
}
