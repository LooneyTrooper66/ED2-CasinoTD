using UnityEngine;
using UnityEngine.UI;

public class ToggleTutorial : MonoBehaviour
{
    public Toggle toggleTutorial;


    private void Start() // sets the toggle to active by default when gaem installed/loaded unless player has already disabled it
    {
        if (PlayerPrefs.GetInt("tutorialToggle") == 0)
        {
            toggleTutorial.isOn = false;
        }
        else
        {
            toggleTutorial.isOn = true;
        }
    }

    public void OnToggleClick()
    {
        if (toggleTutorial.isOn == true)
        {
            PlayerPrefs.SetInt("tutorialToggle", 1);
        }
        if (toggleTutorial.isOn == false)
        {
            PlayerPrefs.SetInt("tutorialToggle", 0);
        }
    }
}
