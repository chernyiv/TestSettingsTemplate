using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioPlayer : MonoBehaviour
{
    [SerializeField]
    private Button musicButton;

    [SerializeField]
    private Button sfxButton;

    [SerializeField]
    private AudioSource musicSource;

    [SerializeField]
    private AudioSource sfxSource;

    private void Start()
    {
        musicButton.onClick.AddListener(PlayMusicSource);
        sfxButton.onClick.AddListener(PlaySFXSource);
    }

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
