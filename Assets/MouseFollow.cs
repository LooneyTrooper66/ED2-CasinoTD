using UnityEngine;

public class MouseFollow : MonoBehaviour
{
    bool onMoblie = true;
    public ParticleSystem PS;
    private Vector2 v2;
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
            v2= Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
        else if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            v2 = Input.GetTouch(0).position;
            
        }
        transform.position = v2;
    }

    public void triggerPartical()
    {
        //trigger burst 
        PS.Play();
        Debug.Log("moew");
    }
}
