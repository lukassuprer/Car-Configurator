using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource soundSource;

    public void PlaySound()
    {
        if (!soundSource.isPlaying)
        {
            soundSource.Play();
            soundSource.loop = true;
        }else if (soundSource.isPlaying)
        {
            soundSource.Stop();
        }
    }
}
