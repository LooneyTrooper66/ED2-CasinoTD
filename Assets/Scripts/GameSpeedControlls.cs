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
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
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
}
