using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour
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
            PickUp();
            Interact();
        }
    }

    private void Interact()
    {
        RaycastHit hit;
        if (Physics.Raycast(GetMouseRay(), out hit, 5f))
        {
            if (hit.transform.tag == "Safe")
            {
                hit.transform.gameObject.GetComponent<Safe>().OpenSafe();
            }
            else if (hit.transform.tag == "Torch")
            {
                var TorchPrefab = Resources.Load("Player (Torch)");
                Vector3 position = gameObject.transform.position;
                Quaternion angle = gameObject.transform.rotation;
                Instantiate(TorchPrefab, position, angle);
                Destroy(hit.transform.gameObject);
                Destroy(gameObject);
            }
            else if (hit.transform.tag == "Gun")
            {
                var GunPrefab = Resources.Load("Player (Gun)");
                Vector3 position = gameObject.transform.position;
                Quaternion angle = gameObject.transform.rotation;
                Instantiate(GunPrefab, position, angle);
                Destroy(hit.transform.gameObject);
                Destroy(gameObject);
            }
            else if (hit.transform.tag == "Note")
            {
                hit.transform.gameObject.GetComponent<Note>().OpenNote();
            }
        }
    }

    private void PickUp()
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

    private Ray GetMouseRay()
    {
        return Camera.main.ScreenPointToRay(Input.mousePosition);
    }
}
