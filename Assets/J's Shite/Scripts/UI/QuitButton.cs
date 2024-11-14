using UnityEngine;
using UnityEngine.UI;

public class QuitButton : MonoBehaviour
{
    [SerializeField] Button quitButton;


    private void Start()
    {
        quitButton.onClick.AddListener(quitPressed);
    }

    public void quitPressed()
    {
        Application.Quit();
        Debug.Log("application quit");
    }
}
