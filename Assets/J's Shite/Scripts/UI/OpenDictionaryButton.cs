using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OpenDictionaryButton : MonoBehaviour
{
    [SerializeField] Button dictButton;


    private void Start()
    {
        dictButton.onClick.AddListener(DictPressed);
    }

    public void DictPressed()
    {
        SceneManager.LoadScene(7);
    }
}
