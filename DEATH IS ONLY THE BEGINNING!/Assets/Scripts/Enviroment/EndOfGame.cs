using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndOfGame : MonoBehaviour
{
    public Image panel;
    public GameObject text;
    float transparent;

    void OnTriggerEnter(Collider other)
    {
        EndTheGame();
    }

    private void EndTheGame()
    {
        StartCoroutine("Fade");
    }

    IEnumerator Fade()
    {
        transparent = panel.color.a;;
        while (transparent < 1)
        {
            transparent += 0.1f;
            panel.color = new Color(0, 0, 0, transparent);
            yield return new WaitForSeconds(0.1f);
        }
        yield return new WaitForSeconds(1);
        text.SetActive(true);
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(0);
    }
}
