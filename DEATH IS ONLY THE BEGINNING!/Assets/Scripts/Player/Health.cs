using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int maxHealth;
    int health;

    public GameObject spawn;

    void Start()
    {
        health = maxHealth;
    }

    void Update()
    {
        if (health <= 0)
        {
            gameObject.GetComponent<CharacterController>().enabled = false;
            gameObject.transform.position = spawn.transform.position;
            gameObject.GetComponent<CharacterController>().enabled = true;
            health = maxHealth;
        }
    }

    public void TakeHealth(int damage)
    {
        health -= damage;
    }
}
