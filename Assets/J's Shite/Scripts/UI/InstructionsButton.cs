using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class InstructionsButton : MonoBehaviour
{
    [SerializeField] Button instructions;


    private void Start()
    {
        instructions.onClick.AddListener(instructionsSceen);
    }

    public void instructionsSceen()
    {
        SceneManager.LoadScene("Instructions");
    }
}
