using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;

public class OptionsScreen : MonoBehaviour
{
    [SerializeField]
    private Toggle fullScreenTog;

    [SerializeField]
    private Toggle vSyncTog;

    [SerializeField]
    private TMP_Text resolutionLabel;

    [SerializeField]
    private TMP_Dropdown resolutionDropdown;

    private Resolution[] resolutions;
    private List<Resolution> filteredResolutions;

    private RefreshRate currentRefreshRate;
    private int currentResolutionIndex;

    void Start()
    {
        fullScreenTog.isOn = Screen.fullScreen;

        vSyncTog.isOn = QualitySettings.vSyncCount != 0;

        resolutions = Screen.resolutions;
        filteredResolutions = new List<Resolution>();
        resolutionDropdown.ClearOptions();
        currentRefreshRate = Screen.currentResolution.refreshRateRatio;

        for(int i = 0; i < resolutions.Length; i++)
        {
            if (resolutions[i].refreshRateRatio.Equals(currentRefreshRate))
            {
                filteredResolutions.Add(resolutions[i]);
            }
        }

        List<string> dropdownOptions = new List<string>(); 
        
        for(int i = 0; i < filteredResolutions.Count; i++) 
        {
            string resolutionOption = filteredResolutions[i].width + " x " + filteredResolutions[i].height + " " + filteredResolutions[i].refreshRateRatio.ToString();
            dropdownOptions.Add(resolutionOption);
            if (filteredResolutions[i].width == Screen.width && filteredResolutions[i].height == Screen.height)
            {
                currentResolutionIndex = i;
            }
        }

        resolutionDropdown.AddOptions(dropdownOptions);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();

    }

    public void UpdateResolution()
    {
        Resolution resolution = filteredResolutions[resolutionDropdown.value];
        currentResolutionIndex = resolutionDropdown.value;
        resolutionDropdown.RefreshShownValue();
    }

    public void ApplyGraphics()
    {
        // Screen.fullScreen = fullScreenTog.isOn;

        if(vSyncTog.isOn) 
        {
            QualitySettings.vSyncCount = 1;
        }
        else
        {
            QualitySettings.vSyncCount = 0; 
        }

        Screen.SetResolution(filteredResolutions[currentResolutionIndex].width, filteredResolutions[currentResolutionIndex].height, fullScreenTog.isOn);
    }
}
