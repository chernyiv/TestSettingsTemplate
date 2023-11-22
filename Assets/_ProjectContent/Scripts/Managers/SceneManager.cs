using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public void LoadTestScene()
    {
        SceneManager.LoadSceneAsync(1);
    }
}
