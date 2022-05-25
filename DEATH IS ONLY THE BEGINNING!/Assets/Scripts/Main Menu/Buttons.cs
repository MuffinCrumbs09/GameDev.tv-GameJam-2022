using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    public void Play(){
        SceneManager.LoadScene(1);
    }

    public void Exit(){
        Application.Quit();
    }

    public void Options(){
        Debug.Log("Options Open");
    }

    public void Feedback(){
        Debug.Log("Feedback Open");
    }
}
