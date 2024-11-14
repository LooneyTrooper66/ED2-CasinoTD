using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SettingsButton : MonoBehaviour
{
    [SerializeField] Button settingsButton;


    private void Start()
    {
        settingsButton.onClick.AddListener(settingsPressed);
    }

    public void settingsPressed()
    {
        SceneManager.LoadScene("SettingsMenu");
    }
}
