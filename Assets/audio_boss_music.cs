using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audio_boss_music : MonoBehaviour
{
    AudioSource audio;

    void Start()
    {
        audio = GetComponent<AudioSource>();
        audio.Play();
    }
}
