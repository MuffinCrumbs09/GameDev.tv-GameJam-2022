using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishDoor : MonoBehaviour
{
    LevelManager lm;

    int turn;

    void Start()
    {
        lm = GameObject.Find("LevelManager").GetComponent<LevelManager>();
    }

    public void FinishLevel()
    {
        if (lm.level == 1)
        {
            lm.level_1_complete = true;
        }
        else if (lm.level == 2)
        {
            if (!lm.level_2_cube)
            {
                lm.level_2_cube = true;
            } else {
                lm.level_2_complete = true;
            }
        }

        Destroy(this);
    }
}
