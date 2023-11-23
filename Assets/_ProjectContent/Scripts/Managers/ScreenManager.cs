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

    private int currentResolutionIndex;

    void Start()
    {
        fullScreenTog.isOn = Screen.fullScreen;

        UpdateResolutionList(Screen.currentResolution.refreshRateRatio);
        fullScreenTog.onValueChanged.AddListener(UpdateFullscreen);
    }

    public void UpdateResolutionList(RefreshRate currentRefreshRate)
    {   
        resolutions = Screen.resolutions;
        filteredResolutions = new List<Resolution>();
        resolutionDropdown.ClearOptions();

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

        resolutionDropdown.onValueChanged.AddListener(UpdateResolution);
    }

    public void SwitchDisplay()
    {

    }

    public void UpdateResolution(int value)
    {
        currentResolutionIndex = value;
        resolutionDropdown.RefreshShownValue();
        ScreenData.resolution = filteredResolutions[currentResolutionIndex];
    }

    public void UpdateFullscreen(bool isTogOn)
    {
        ScreenData.fullScreenMode = isTogOn ? FullScreenMode.ExclusiveFullScreen : FullScreenMode.Windowed;
        GetComponent<RefreshRateManager>().UpdateRefreshRateList();
    }
}
