using UnityEngine;

public class TutorialEnableDisable : MonoBehaviour
{
    private void Start()
    {
        if (PlayerPrefs.GetInt("tutorialToggle") == 0)
        {
            gameObject.SetActive(false);
        }
    }
}
