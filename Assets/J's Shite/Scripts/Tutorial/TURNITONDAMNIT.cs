using UnityEngine;

public class TURNITONDAMNIT : MonoBehaviour
{    
    private void Awake() // sets the toggle to active by default when gaem installed/loaded unless player has already disabled it
    {
        // this should make it so the tutorial is automatically on when you first load up the game
        if (!PlayerPrefs.HasKey("tutorialToggle"))
        {
            PlayerPrefs.SetInt("tutorialToggle", 1);
            return;
        }
    }
}
