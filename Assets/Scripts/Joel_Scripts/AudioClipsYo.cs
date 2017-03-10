using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioClipsYo : MonoBehaviour {

    public AudioClip sound1;
    public AudioClip sound2;
   // public AudioClip sound3;

    public AudioSource audioNew;

    void Start()
    {
        audioNew = GetComponent<AudioSource>();
    }

    public void playLevelUp()
    {

        audioNew.PlayOneShot(sound2, 0.7f);
        audioNew.PlayOneShot(sound1, 1);
        
    }

}
