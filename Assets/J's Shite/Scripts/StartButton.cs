using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{
    [SerializeField] Button startButton;


    private void Start()
    {
        startButton.onClick.AddListener(startPressed);
    }

    void startPressed()
    {
        SceneManager.LoadScene("gameScene");
    }
}
