using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RefreshRateManager : MonoBehaviour
{
    [SerializeField]
    private TMP_Dropdown refreshRateDropdown;

    private Resolution[] resolutions;
    private List<RefreshRate> refreshRatesList;

    private int currentRefreshRateIndex;

    void Start()
    {
        resolutions = Screen.resolutions;
        refreshRateDropdown.ClearOptions(); 

        refreshRatesList = new List<RefreshRate>();

        for (int i = 0; i < resolutions.Length; i++)
        {
            if (refreshRatesList.Contains(resolutions[i].refreshRateRatio))
            {
                continue;
            }

            refreshRatesList.Add(resolutions[i].refreshRateRatio);
        }

        List<string> dropdownOptions = new List<string>();

        for (int i = 0; i < refreshRatesList.Count; i++)
        {
            string refreshRateOption = refreshRatesList[i].ToString();
            dropdownOptions.Add(refreshRateOption);
            if (refreshRatesList[i].Equals(Screen.currentResolution.refreshRateRatio))
            {
                currentRefreshRateIndex = i;
                ScreenData.refreshRate = refreshRatesList[i];
            }
        }

        refreshRateDropdown.AddOptions(dropdownOptions);
        refreshRateDropdown.value = currentRefreshRateIndex;
        refreshRateDropdown.RefreshShownValue();

        refreshRateDropdown.onValueChanged.AddListener(UpdateRefreshRate);
    }

    public void UpdateRefreshRate(int index)
    {
        currentRefreshRateIndex = index;
        refreshRateDropdown.RefreshShownValue();
        RefreshRateData.refreshRate = refreshRatesList[currentRefreshRateIndex];
    }
}