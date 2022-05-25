using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorchRayCast : MonoBehaviour
{
    ToggleTorch torch;
    public Transform ray;

    void Start()
    {
        torch = GetComponent<ToggleTorch>();
    }

    void Update()
    {
        if(torch.on){
            RaycastHit hit;
            Vector3 dir = ray.TransformDirection(Vector3.forward);

            if(Physics.Raycast(ray.position, dir, out hit)){
                if(hit.transform.tag == "TorchButton"){
                    hit.transform.GetComponent<TorchButton>().DoSomething();
                }
            }
        }
    }
}
