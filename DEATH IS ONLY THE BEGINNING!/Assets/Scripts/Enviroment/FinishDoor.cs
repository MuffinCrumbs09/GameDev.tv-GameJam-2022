using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishDoor : MonoBehaviour
{
    LevelManager lm;

    void Start()
    {
        lm = GameObject.Find("LevelManager").GetComponent<LevelManager>();
    }

    public void FinishLevel(){
        if(lm.level == 1){
            lm.level_1_complete = true;
        }
    }
}
