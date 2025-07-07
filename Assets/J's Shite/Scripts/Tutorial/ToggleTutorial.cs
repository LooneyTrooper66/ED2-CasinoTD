using UnityEngine;
using UnityEngine.UI;

public class ToggleTutorial : MonoBehaviour
{
    public Toggle toggleTutorial;
    public UIButtonNoise noise;


    private void Awake() // sets the toggle to active by default when gaem installed/loaded unless player has already disabled it
    {
        // this should make it so the tutorial is automatically on when you first load up the game
        if (!PlayerPrefs.HasKey("tutorialToggle"))
        {
            toggleTutorial.isOn = true;
            return;
        }

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
        noise.OnClick();
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
