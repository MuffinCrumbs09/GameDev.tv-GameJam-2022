using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShootSelf : MonoBehaviour
{
    float time;

    void Start()
    {
        AnimationClip[] clips = GetComponent<Animator>().runtimeAnimatorController.animationClips;
        foreach (AnimationClip clip in clips)
        {
            if (clip.name == "Shootself")
            {
                time = clip.length - 0.1f;
                Debug.Log(time);
            }
        }
    }
    void Update()
    {
        if (Input.GetMouseButton(0))
        {

            StartCoroutine(ShootingSelf());
        }
    }

    IEnumerator ShootingSelf()
    {
        GetComponent<Animator>().Play("Shootself");
        yield return new WaitForSeconds(time);
        SceneManager.LoadScene(5);
    }
}
