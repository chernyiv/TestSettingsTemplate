using UnityEngine;
using UnityEngine.UI;

public class AppController : MonoBehaviour
{
    [SerializeField]
    private Button exitButton;

    private void Start()
    {
        exitButton.onClick.AddListener(Exit);
    }

    public void Exit()
    {
        Application.Quit();
    }
}