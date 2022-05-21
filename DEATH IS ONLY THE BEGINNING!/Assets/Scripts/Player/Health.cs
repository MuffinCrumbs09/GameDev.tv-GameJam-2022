using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    public int maxHealth;
    int health;

    public GameObject spawn;

    void Start()
    {
        health = maxHealth;
        GameObject.Find("LevelManager").GetComponent<LevelManager>().level++;
    }

    void Update()
    {
        if (health <= 0)
        {
            DontDestroyOnLoad(GameObject.Find("LevelManager"));
            SceneManager.LoadScene(GameObject.Find("LevelManager").GetComponent<LevelManager>().level + 1);
        }
    }

    public void TakeHealth(int damage)
    {
        health -= damage;
    }
}
