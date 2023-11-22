using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsController : MonoBehaviour
{
    [SerializeField]
    private Button openOptionsButton;

    [SerializeField]
    private Button closeOptionsButton;

    [SerializeField]
    private GameObject optionsScreen;

    [SerializeField]
    private ControllablePanel[] controllablePanels;

    [Serializable]
    private struct ControllablePanel
    {
        [SerializeField]
        private GameObject panel;

        [SerializeField]
        private Button button;

        public GameObject Panel => panel;
        public Button Button => button;
    }

    private GameObject activePanel;

    void Start()
    {   
        openOptionsButton.onClick.AddListener(SwitchOptions);
        closeOptionsButton.onClick.AddListener(SwitchOptions);

        activePanel = controllablePanels[0].Panel;

        foreach (var controllablePanel in controllablePanels) 
        {   
            controllablePanel.Button.onClick.AddListener( () =>
            {
                activePanel.SetActive(false);   
                activePanel = controllablePanel.Panel;
                activePanel.SetActive(true);
            });
        }
    }

    public void SwitchOptions()
    {
        optionsScreen.SetActive(!optionsScreen.activeSelf);
    }
}
