using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScreenManager : MonoBehaviour
{
    [SerializeField]
    private Toggle fullScreenTog;

    [SerializeField]
    private TMP_Dropdown resolutionDropdown;

    private Resolution[] resolutions;
    private List<Resolution> filteredResolutions;

    private RefreshRate currentRefreshRate;
    private int currentResolutionIndex;

    void Start()
    {
        fullScreenTog.isOn = Screen.fullScreen;

        resolutions = Screen.resolutions;
        filteredResolutions = new List<Resolution>();
        resolutionDropdown.ClearOptions();
        currentRefreshRate = Screen.currentResolution.refreshRateRatio;

        for (int i = 0; i < resolutions.Length; i++)
        {
            if (resolutions[i].refreshRateRatio.Equals(currentRefreshRate))
            {
                filteredResolutions.Add(resolutions[i]);
            }
        }

        List<string> dropdownOptions = new List<string>();

        for (int i = 0; i < filteredResolutions.Count; i++)
        {
            string resolutionOption = filteredResolutions[i].width + " x " + filteredResolutions[i].height + " " + filteredResolutions[i].refreshRateRatio.ToString() + "Hz";
            dropdownOptions.Add(resolutionOption);
            if (filteredResolutions[i].width == Screen.width && filteredResolutions[i].height == Screen.height)
            {
                currentResolutionIndex = i;
                ScreenData.resolution = filteredResolutions[i];
            }
        }

        resolutionDropdown.AddOptions(dropdownOptions);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();
    }

    public void UpdateResolution()
    {
        currentResolutionIndex = resolutionDropdown.value;
        resolutionDropdown.RefreshShownValue();
        ScreenData.resolution = filteredResolutions[currentResolutionIndex];
    }

    public void UpdateFullscreen()
    {
        ScreenData.isFullScreen = fullScreenTog.isOn;
    }
}
