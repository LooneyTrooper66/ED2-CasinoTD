using UnityEngine;
using UnityEngine.UI;

public class DictionaryButtons : MonoBehaviour
{
    public Canvas mainCanv;
    public Canvas towersCanv;
    public Canvas evemiesCanv;


    public void BackButton()
    {
        towersCanv.enabled = false;
        evemiesCanv.enabled = false;

        mainCanv.enabled = true;
    }
    public void TowersButton()
    {
        mainCanv.enabled = false;
        evemiesCanv.enabled = false;

        towersCanv.enabled = true;
    }
    public void EnemiesButton()
    {
        towersCanv.enabled = false;
        mainCanv.enabled = false;

        evemiesCanv.enabled = true;
    }
}
