using UnityEngine;

public class GraphicsManager : MonoBehaviour
{
    public void ApplyGraphics()
    {   
        QualitySettings.vSyncCount = VsyncData.vSyncCount;
        Screen.SetResolution(ScreenData.resolution.width, ScreenData.resolution.height, ScreenData.isFullScreen);
    }
}
