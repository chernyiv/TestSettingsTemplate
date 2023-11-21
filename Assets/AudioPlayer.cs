using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    [SerializeField]
    private AudioSource musicSource;

    [SerializeField]
    private AudioSource sfxSource;

    public void PlayMusicSource()
    {
        if (musicSource.isPlaying)
        {
            musicSource.Stop();
        }
        else
        {
            musicSource.Play();
        }
    }

    public void PlaySFXSource()
    {
        if (sfxSource.isPlaying)
        {
            sfxSource.Stop();
        }
        else
        {
            sfxSource.Play();
        }
    }
}
