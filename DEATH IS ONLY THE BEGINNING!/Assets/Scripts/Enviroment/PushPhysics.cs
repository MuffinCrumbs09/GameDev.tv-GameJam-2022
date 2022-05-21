using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushPhysics : MonoBehaviour
{
    int pushPower = 2;
    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.transform.tag == "Red")
        {
            Rigidbody body = hit.gameObject.GetComponent<Rigidbody>();

            if (body == null || body.isKinematic) { return; }

            Vector3 pushDir = new Vector3(hit.moveDirection.x, 0, hit.moveDirection.z);

            body.velocity = pushDir * pushPower;
        }

    }
}
