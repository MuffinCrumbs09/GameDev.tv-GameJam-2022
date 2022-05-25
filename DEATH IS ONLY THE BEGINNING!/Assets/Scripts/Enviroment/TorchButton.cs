using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorchButton : MonoBehaviour
{
    public GameObject target;

    public void DoSomething(){
        target.SetActive(true);
    }
}
