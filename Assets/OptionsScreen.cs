using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class OptionsScreen : MonoBehaviour
{
    public Toggle fullScreenTog;
    public Toggle vSyncTog;
    public List<ResolutionItem> resolutions = new List<ResolutionItem>();
    private int selectedResolution;
    public TMP_Text resolutionLabel;


    // Start is called before the first frame update
    void Start()
    {
        fullScreenTog.isOn = Screen.fullScreen; 

        if(QualitySettings.vSyncCount == 0)
        {
            vSyncTog.isOn = false;
        } else
        {
            vSyncTog.isOn = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SwitchResolutionLeft()
    {
        selectedResolution--;
        if(selectedResolution < 0) 
        {
            selectedResolution = 0;
        }

        UpdateResolution();
    }

    public void SwitchResolutionRight()
    {
        selectedResolution++;
        if(selectedResolution > resolutions.Count - 1)
        {
            selectedResolution = resolutions.Count - 1;
        }

        UpdateResolution();
    }

    public void UpdateResolution()
    {
        resolutionLabel.text = resolutions[selectedResolution].horizontal.ToString() + " x " + resolutions[selectedResolution].vertical.ToString();
    }

    public void ApplyGraphics()
    {
        // Screen.fullScreen = fullScreenTog.isOn;

        if(vSyncTog.isOn ) 
        {
            QualitySettings.vSyncCount = 1;
        }
        else
        {
            QualitySettings.vSyncCount = 0; 
        }

        Screen.SetResolution(resolutions[selectedResolution].horizontal, resolutions[selectedResolution].vertical, fullScreenTog.isOn);
    }
}

[System.Serializable]
public class ResolutionItem
{
    public int horizontal;
    public int vertical;
}
