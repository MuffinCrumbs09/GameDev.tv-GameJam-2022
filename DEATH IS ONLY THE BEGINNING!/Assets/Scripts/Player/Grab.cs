using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grab : MonoBehaviour
{
    public Transform Destination;

    GameObject picked;
    bool pickedBool;

    void Update()
    {

        if (pickedBool)
        {
            picked.transform.position = Destination.position;
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            if (!pickedBool)
            {
                RaycastHit hit;
                if (Physics.Raycast(GetMouseRay(), out hit, 5f))
                {
                    if (hit.transform.GetComponent<Rigidbody>() != null && hit.transform.tag == "Green")
                    {
                        pickedBool = true;
                        picked = hit.transform.gameObject;
                        picked.GetComponent<Rigidbody>().useGravity = false;
                        picked.transform.position = Destination.position;
                    }
                }
            }
            else
            {
                pickedBool = false;
                picked.GetComponent<Rigidbody>().useGravity = true;
                picked = null;
            }
        }
    }

    private Ray GetMouseRay()
    {
        return Camera.main.ScreenPointToRay(Input.mousePosition);
    }
}
