using TMPro;
using Unity.VisualScripting;
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

        masterSoundLabel.text = SoundValueToString(masterSlider.value);
        musicSoundLabel.text = SoundValueToString(musicSlider.value);
        sfxSoundLabel.text = SoundValueToString(sfxSlider.value);

        masterSlider.onValueChanged.AddListener(SetMasterVolume);
        musicSlider.onValueChanged.AddListener(SetMusicVolume);
        sfxSlider.onValueChanged.AddListener(SetSFXVolume);
    }

    public void SetMasterVolume(float value) 
    {
        masterSoundLabel.text = SoundValueToString(value);

        mixer.SetFloat("MasterVol", LogarithmAudioValue(value));

        PlayerPrefs.SetFloat("MasterVol", value); 
    }

    public void SetMusicVolume(float value)
    {
        musicSoundLabel.text = SoundValueToString(value);

        mixer.SetFloat("MusicVol", LogarithmAudioValue(value));

        PlayerPrefs.SetFloat("MusicVol", value);
    }

    public void SetSFXVolume(float value)
    {
        sfxSoundLabel.text = SoundValueToString(value);

        mixer.SetFloat("SFXVol", LogarithmAudioValue(value));

        PlayerPrefs.SetFloat("SFXVol", value);
    }

    private float LogarithmAudioValue(float value)
    {
        return Mathf.Log10(value) * 20;
    }
    
    private string SoundValueToString(float value)
    {
        return Mathf.Ceil(value * 100).ToString();
    }
}
