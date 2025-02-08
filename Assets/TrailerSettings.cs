using UnityEngine;
using UnityEditor.SceneManagement;
using UnityEngine.SceneManagement;

public class TrailerSettings : MonoBehaviour
{
    [SerializeField] float i = 1;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    // Update is called once per frame
    void Update()
    {
        //get key presses to do stuff
        if (Input.GetKeyDown(KeyCode.R));
        {
            ResetScene();
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Play();
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            i += 0.25f;
            Time.timeScale = i;
        }
        if (Input.GetKeyDown(KeyCode.O))
        {
            i = i/4;
            Time.timeScale = i;
        }
    }

    private void ResetScene()
    {
        //load the scene again :3 uwu
        SceneManager.SetActiveScene(SceneManager.GetActiveScene());
    }

    private void Play()
    {
        //load the scene again :3 uwu
    }

}
