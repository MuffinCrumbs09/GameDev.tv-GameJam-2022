using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorchButton : MonoBehaviour
{
    public GameObject target;

    public void DoSomething(){
        target.GetComponent<Animator>().SetTrigger("Open");
        target.GetComponent<BoxCollider>().enabled = false;
    }
}
