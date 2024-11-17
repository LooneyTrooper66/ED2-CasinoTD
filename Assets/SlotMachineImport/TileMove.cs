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

    public bool rowHost;//
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!Host.stop)
        {
            //transform.Translate(Vector3.down * (speed * Time.deltaTime));
            transform.position = Vector3.MoveTowards(transform.position, exit.transform.position, speed * Time.deltaTime);
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

    }


}
