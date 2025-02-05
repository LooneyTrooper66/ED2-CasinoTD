using UnityEngine;

public class MouseFollow : MonoBehaviour
{
    bool onMoblie = true;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if(Application.platform == RuntimePlatform.WindowsEditor || Application.platform == RuntimePlatform.WindowsPlayer || Application.platform == RuntimePlatform.LinuxPlayer)
        {
            onMoblie = false;
        }
        else
        {
            onMoblie = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //get mouse pos
        if (onMoblie == false)
        {
            transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
    }

    public void triggerPartical()
    {
        //trigger burst 
    }
}
