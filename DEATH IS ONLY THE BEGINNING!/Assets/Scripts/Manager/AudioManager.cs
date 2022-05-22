using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioClip[] clips;
    int clip;
    bool played;
    bool choose;
    bool started;

    AudioSource a;

    void Start()
    {
        a = GetComponent<AudioSource>();
        played = true;
        choose = true;

        clip = -1;
    }

    void Update()
    {
        if (!started) { StartCoroutine("playClip"); }
    }


    IEnumerator playClip()
    {
        if (a.clip != null && !played)
        {
            started = true;
            a.Play();
            yield return new WaitForSeconds(a.clip.length);
            played = true;
        }
    }

    public void nextClip()
    {
        clip++;
        choose = false;
        played = false;
        started = false;
        if (clip <= clips.Length && !choose)
        {
            a.clip = clips[clip];
            choose = true;
        }
    }

    public bool choosen()
    {
        if (choose && played)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public int getClip(){
        return clip;
    }
}
