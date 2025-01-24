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
            if (fadeOutDone == false)
            {
                if (sR.color.a >= 0.3)
                {
                    Color sCol = sR.color;
                    float val = sCol.a - 0.001f;
                    sR.color = new Color(sCol.r, sCol.g, sCol.b, val);
                }
                else
                {
                    fadeOutDone = true;
                    fadeInDone = false;
                }
            }
        }
        else
        {
            if (fadeInDone == false)
            {
                if (sR.color.a <= 1)
                {
                    Color sCol = sR.color;
                    float val = sCol.a + 0.001f;
                    sR.color = new Color(sCol.r, sCol.g, sCol.b, val);
                }
                else
                {
                    fadeInDone = true;
                    fadeOutDone = false;
                }
            }
        }
    }
}

/*
 if (transform.y >= 2.5f)
{
    // deactivate this tiles children until lever pulled again
}
 */