using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BedroomAudio : MonoBehaviour
{
    AudioManager am;

    void Start()
    {
        am = GameObject.Find("AudioPlayer").GetComponent<AudioManager>();
    }

    void OnTriggerStay(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            if (am.choosen() && am.getClip() != 1)
            {
                am.nextClip();
            }

            if(am.choosen() && am.getClip() == 1){
                GameObject.Find("DoorCollider").GetComponent<OpenDoor>().Open();
                Destroy(this);
            }
        }
    }
}
