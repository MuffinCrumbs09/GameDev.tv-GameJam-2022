using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wakeup : MonoBehaviour
{
    public GameObject[] turnOn;

    void Start()
    {
        foreach (GameObject obj in turnOn)
        {
            obj.SetActive(false);
        }
    }
    public void Wake()
    {
        foreach (GameObject obj in turnOn)
        {
            obj.SetActive(true);
        }
        Destroy(gameObject);
    }
}
