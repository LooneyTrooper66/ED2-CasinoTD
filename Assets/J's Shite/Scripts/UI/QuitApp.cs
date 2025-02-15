using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class QuitApp : MonoBehaviour
{
    [SerializeField] Button quitButton;


    private void Start()
    {
        quitButton.onClick.AddListener(quitPressed);
    }

    public void quitPressed()
    {
        Application.Quit();
    }
}