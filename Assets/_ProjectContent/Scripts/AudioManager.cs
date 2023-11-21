using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    [SerializeField]
    private AudioMixer mixer;

    [SerializeField]
    private TMP_Text masterSoundLabel;

    [SerializeField]
    private TMP_Text musicSoundLabel;

    [SerializeField]
    private TMP_Text sfxSoundLabel;

    [SerializeField]
    private Slider masterSlider;

    [SerializeField]
    private Slider musicSlider;

    [SerializeField]
    private Slider sfxSlider;

    private void Start()
    {
        string[] volumeKeys = { "MasterVol", "MusicVol", "SFXVol" };

        foreach(string key in volumeKeys)
        {
            if (PlayerPrefs.HasKey(key))
            {
                mixer.SetFloat(key, PlayerPrefs.GetFloat(key));
                float volume = 0f;
                mixer.GetFloat(key, out volume);
                switch(key)
                {
                    case "MasterVol":
                        masterSlider.value = volume;
                        break;

                    case "MusicVol":
                        musicSlider.value = volume;
                        break;
                    case "SFXVol":
                        sfxSlider.value = volume;
                        break;
                }
            }
        }

        masterSoundLabel.text = (masterSlider.value + 80).ToString();
        musicSoundLabel.text = (musicSlider.value + 80).ToString();
        sfxSoundLabel.text = (sfxSlider.value + 80).ToString();
    }

    public void SetMasterVolume() 
    {
        masterSoundLabel.text = (masterSlider.value + 80).ToString();

        mixer.SetFloat("MasterVol", masterSlider.value);

        PlayerPrefs.SetFloat("MasterVol", masterSlider.value);
    }

    public void SetMusicVolume()
    {
        musicSoundLabel.text = (musicSlider.value + 80).ToString();

        mixer.SetFloat("MusicVol", musicSlider.value);

        PlayerPrefs.SetFloat("MusicVol", musicSlider.value);
    }

    public void SetSFXVolume()
    {
        sfxSoundLabel.text = (sfxSlider.value + 80).ToString();

        mixer.SetFloat("SFXVol", sfxSlider.value);

        PlayerPrefs.SetFloat("SFXVol", sfxSlider.value);
    }
}
