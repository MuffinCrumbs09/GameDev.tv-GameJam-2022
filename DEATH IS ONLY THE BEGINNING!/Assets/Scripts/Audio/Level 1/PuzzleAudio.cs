using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LevelOne
{
    public class PuzzleAudio : MonoBehaviour
    {
        AudioManager am;
        LevelManager lm;

        void Start()
        {
            am = GameObject.Find("AudioPlayer").GetComponent<AudioManager>();
            lm = GameObject.Find("LevelManager").GetComponent<LevelManager>();
        }

        void OnTriggerStay(Collider other)
        {
            if (other.transform.tag == "Player")
            {
                if (am.choosen() && am.getClip() != 1)
                {
                    am.nextClip();
                }

                if (am.choosen() && lm.level_1_complete)
                {
                    am.nextClip();
                    Destroy(this);
                }
            }
        }
    }
}
