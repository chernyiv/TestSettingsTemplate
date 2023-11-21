using System.Collections.Generic;
using UnityEngine;

public class OptionsScreen : MonoBehaviour
{   
    [SerializeField]
    private GameObject graphicsPanel;

    [SerializeField]
    private GameObject audioPanel;

    [SerializeField]
    private GameObject controlsPanel;

    private List<GameObject> panels;

    void Start()
    {
        panels = new List<GameObject>
        {
            graphicsPanel,
            audioPanel,
            controlsPanel
        };
    }

    public void OpenGraphicsPanel()
    {   
        CloseAllPanels();
        graphicsPanel.SetActive(true);
    }

    public void OpenAudioPanel()
    {   
        CloseAllPanels();
        audioPanel.SetActive(true);
    }

    public void OpenControlsTab()
    {   
        CloseAllPanels();
        controlsPanel.SetActive(true);
    }

    private void CloseAllPanels()
    {
        panels.ForEach(x =>
        {
            x.gameObject.SetActive(false);
        });
    }
}
