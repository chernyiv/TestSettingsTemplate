using UnityEngine;
using UnityEngine.UI;

public class VsyncManager : MonoBehaviour
{
    [SerializeField]
    private Toggle vSyncTog;

    void Start()
    {
        vSyncTog.isOn = QualitySettings.vSyncCount != 0;
        vSyncTog.onValueChanged.AddListener(UpdateVsync);
    }

    public void UpdateVsync(bool isTogOn)
    {
        VsyncData.vSyncCount = isTogOn ? 1 : 0;
    }
}
