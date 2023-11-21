using UnityEngine;
using UnityEngine.UI;

public class VsyncManager : MonoBehaviour
{
    [SerializeField]
    private Toggle vSyncTog;

    void Start()
    {
        vSyncTog.isOn = QualitySettings.vSyncCount != 0;
    }

    public void UpdateVsync()
    {
        if (vSyncTog.isOn)
        {
            VsyncData.vSyncCount = 1;
        }
        else
        {
            VsyncData.vSyncCount = 0;
        }
    }

}
