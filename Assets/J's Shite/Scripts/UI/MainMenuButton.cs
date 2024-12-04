using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuButton : MonoBehaviour
{
    [SerializeField] Button mainMenu;


    private void Start()
    {
        mainMenu.onClick.AddListener(goToMenu);
    }

    public void goToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
