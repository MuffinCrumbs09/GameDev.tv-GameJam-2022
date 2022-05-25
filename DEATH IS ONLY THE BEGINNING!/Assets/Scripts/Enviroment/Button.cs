using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace enviroment
{
    public class Button : MonoBehaviour
    {
        public GameObject ObjectToChange;
        void OnTriggerEnter(Collider other)
        {
            Open();
        }

        void OnTriggerExit(Collider other)
        {
            Close();
        }


        void Open()
        {
            if (ObjectToChange.GetComponent<Animator>() != null)
            {
                ObjectToChange.GetComponent<Animator>().SetTrigger("Open");

                if (ObjectToChange.GetComponent<FinishDoor>() != null)
                {
                    ObjectToChange.GetComponent<FinishDoor>().FinishLevel();
                }
            }
        }

        void Close()
        {
            if (ObjectToChange.GetComponent<Animator>() != null)
            {
                ObjectToChange.GetComponent<Animator>().SetTrigger("Close");
            }
        }
    }
}
