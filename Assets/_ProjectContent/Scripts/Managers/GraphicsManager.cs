using UnityEngine;
using UnityEngine.UI;

public class GraphicsManager : MonoBehaviour
{

    [SerializeField]
    private Button applyOptionsButton;

    private void Start()
    {
        applyOptionsButton.onClick.AddListener(ApplyGraphics);    
    }

    public void ApplyGraphics()
    {   
        QualitySettings.vSyncCount = VsyncData.vSyncCount;
        Screen.SetResolution(ScreenData.resolution.width, ScreenData.resolution.height, ScreenData.fullScreenMode, ScreenData.refreshRate);
    }
}
