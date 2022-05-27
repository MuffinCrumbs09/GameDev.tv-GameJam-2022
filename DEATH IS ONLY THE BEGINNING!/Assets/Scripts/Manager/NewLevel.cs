using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewLevel : MonoBehaviour
{
    void Start()
    {
        GameObject.Find("LevelManager").GetComponent<LevelManager>().level++;
    }
}
