using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileMove : MonoBehaviour
{
    public float speed;
    public GameObject exit;
    public Transform entrance;
    public Vector3 slotPos;

    public RowRandomiser Host;
    public bool stopSpin;
    public bool stop;
    [SerializeField] private enemy_Manager eM;
    private SpriteRenderer sR;
    private float alphaVal = 225;
    bool fadeInDone = true;
    bool fadeOutDone = false;

    public bool rowHost;//
    // Start is called before the first frame update
    void Start()
    {
        sR = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!Host.stop)
        {
            //transform.Translate(Vector3.down * (speed * Time.deltaTime));
           // transform.position = Vector3.MoveTowards(transform.position, exit.transform.position, speed * Time.deltaTime);
            transform.position += speed * Time.deltaTime * Vector3.down;
        }

        if (stop && transform.position.y <= slotPos.y && rowHost)
        {
            Host.Stop();
            stopSpin = false;
            //rowHost = false;
            //Debug.Log(gameObject);
        }

        if (transform.position.y <= exit.transform.position.y)
        {
            transform.position = entrance.position;
            if (stopSpin && rowHost)
            {
                Host.slowing = true;
                stop = true;
            }
        }


        // MAKE IT SO THE ALPHA FADES IN AND OUT INSTEAD OF CHANGING THE SPRITE COLOUR TO GREY
        if (eM.waveState == enemy_Manager.WaveState.WaveSpawning || eM.waveState == enemy_Manager.WaveState.WaveActive)
        {

            Debug.Log(sR.color.a);
            if (fadeOutDone == false)
            {
                StartCoroutine(AlphaFadeOut());
                fadeInDone = false;
            }
        }
        else
        {
            if (fadeInDone == false)
            {
                StartCoroutine(AlphaFadeIn());
                fadeOutDone = false;
            }
        }
    }

    IEnumerator AlphaFadeOut()
    {
        fadeOutDone = true;
        while (sR.color.a != 50)
        {
            sR.color = new Color(225, 225, 225, alphaVal);
            alphaVal = alphaVal - 5;
        }
        yield return null;
    }

    IEnumerator AlphaFadeIn()
    {
        fadeInDone = true;
        while (sR.color.a != 225)
        {
            sR.color = new Color(225, 225, 225, alphaVal);
            alphaVal++;
        }
        yield return null;
    }
}

/*
 if (transform.y >= 2.5f)
{
    // deactivate this tiles children until lever pulled again
}
 */