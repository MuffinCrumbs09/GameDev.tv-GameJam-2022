using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace player
{
    public class Movement : MonoBehaviour
    {

        public float speed = 5;
        public float sprint = 8;
        public Camera pc;
        float jumpHeight = 8;
        float sensitivity = 2;
        public float gravity = 20;
        public float xlimit = 70;
        float rotationX = 0;
        public CharacterController cc;
        public Vector3 moveDirection;
        public bool movement;

        void Start()
        {
            movement = true;

            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
        void Update()
        {
            rotationX += -Input.GetAxis("Mouse Y") * sensitivity;
            rotationX = Mathf.Clamp(rotationX, -xlimit, xlimit);
            pc.transform.localRotation = Quaternion.Euler(rotationX, 180, 0);
            transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * sensitivity, 0);

            Vector3 forward = transform.TransformDirection(Vector3.forward);
            Vector3 right = transform.TransformDirection(Vector3.right);

            bool running = Input.GetKey(KeyCode.LeftShift);

            float curSpeedX = (running ? sprint : speed) * Input.GetAxis("Vertical");
            float curSpeedY = (running ? sprint : speed) * Input.GetAxis("Horizontal");

            float movementDirectionY = moveDirection.y;

            if (movement)
            {
                moveDirection = (-forward * curSpeedX) + (-right * curSpeedY);
            }

            if (Input.GetKeyDown(KeyCode.Space) && cc.isGrounded)
            {
                moveDirection.y = jumpHeight;
            }
            else
            {
                moveDirection.y = movementDirectionY;
            }

            if (!cc.isGrounded)
            {
                moveDirection.y -= gravity * Time.deltaTime;
            }

            cc.Move(moveDirection * Time.deltaTime);
        }
    }
}
