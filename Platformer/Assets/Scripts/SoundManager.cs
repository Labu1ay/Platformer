using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource Music;

    public void SetMusicEnabled(bool value)
    {
        Music.enabled = value;
    }

    public void SetMusicValue(float value)
    {
        AudioListener.volume = value;
    }
}

