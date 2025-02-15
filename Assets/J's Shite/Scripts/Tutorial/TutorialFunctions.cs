using UnityEngine;
using System.Collections;

public class TutorialFunctions : MonoBehaviour
{
    public GameObject[] panels;
    public int PannelCount = 0;
    public Collider2D contingencyCol;


    public void SwitchTalk()
    {
        switch (PannelCount)
        {
            case 0:
                panels[0].gameObject.SetActive(false);
                panels[1].gameObject.SetActive(true);
                PannelCount++;
                break;
            case 1:
                panels[1].gameObject.SetActive(false);
                panels[2].gameObject.SetActive(true);
                PannelCount++;
                break;
            case 2:
                panels[2].gameObject.SetActive(false);
                panels[3].gameObject.SetActive(true);
                PannelCount++;
                break;
            case 3:
                panels[3].gameObject.SetActive(false);
                panels[4].gameObject.SetActive(true);
                PannelCount++;
                break;
            case 4:
                panels[4].gameObject.SetActive(false);
                panels[5].gameObject.SetActive(true);
                PannelCount++;
                break;

            case 5:
                panels[5].gameObject.SetActive(false);
                panels[6].gameObject.SetActive(true);
                PannelCount++;
                break;
            case 6:
                panels[6].gameObject.SetActive(false);
                contingencyCol.enabled = false;
                break;


        }
    }

    private void Update()
    {
        if ((Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began) || Input.GetMouseButtonUp(0)) // i this i fixed this?
        {
            if (PannelCount <= 6)
            {
                SwitchTalk();
            }
        }
    }
}
