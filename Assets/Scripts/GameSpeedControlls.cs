using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class GameSpeedControlls : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public TMP_Text text;
    private float i;
    void Start()
    {
        Time.timeScale = 1;
        i = 0;
        text.text = new string((i + 1) + "X");
    }

    // Update is called once per frame

    public void gameSpeedUpdate()
    {
        i++;
        switch (i)
        {
            case 1:
                Time.timeScale = 2f;
                break;
            case 2:
                Time.timeScale = 3f;
                break;
            case 3:
                Time.timeScale = 4f;
                break ;
            case 4:
                Time.timeScale = 5f;
                break;
            default:
                i = 0;
                Time.timeScale = 1f;
                break;
        }
        text.text = new string((i + 1) + "X");
    }


    private void OnDisable()
    {
        //Debug.Log("Disabled");
        Time.timeScale = 1;
    }
}
