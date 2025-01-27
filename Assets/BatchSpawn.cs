using System.Collections.Generic;
using UnityEngine;

public class BatchSpawn : MonoBehaviour
{
    public GameObject coinPreFab;
    public Vector2 boundingBox;
    public int coinCount;
    public bool GateState;
    public bool GateInAction;

    public GameObject gateLeft;
    public GameObject gateRight;

    public Transform gateLOpenPos;
    public Transform gateROpenPos;

    private Vector3 rClosePos;
    private Vector3 lClosePos;
    [SerializeField] bool debugTrigger;
    [SerializeField] bool debugTriggerGate;
    float i = 0;
    public float speed;
    public float w;
    bool waitTrue;
    float timer;
    int chipSpawnCount;
    bool chipSpawning;
    float doorWait;
    bool OpenDoorWait;
    float dw = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        coinPoolCreation(); 
        //coinSpawn();
        rClosePos = gateRight.transform.position;
        lClosePos = gateLeft.transform.position;
        i = 0;
        // this.transform.GetChild(1)
    }

    // Update is called once per frame
    void Update()
    {
        if (debugTrigger)
        {
            debugTrigger = false;
            coinSpawn();
        }

        if (debugTriggerGate) //activate gate
        {
            GateState = GateState ? GateState = false : GateState = true;
            debugTriggerGate = false;
            i = 0;
            GateInAction= true;
            OpenGateResetGate();
        }
        if (GateInAction) // if gate is inaction repeate
        {
            OpenGateResetGate();
            
            i = i>1? 1 : i += Time.deltaTime * speed;
        }

        if (OpenDoorWait)
        {
            dw += Time.deltaTime;
            if (dw >= doorWait)
            {
                debugTriggerGate = true;
                waitTrue = false;
            }
        }

        if (waitTrue)
        {
            w += Time.deltaTime;
            if (w >= timer)
            {
                debugTriggerGate = true;
                waitTrue = false;
            }
        }
        if (chipSpawning)
        {
            if (chipSpawnCount >= coinCount+1) { chipSpawning = false; return; }
            GameObject gM = transform.GetChild(chipSpawnCount).gameObject;
            gM.transform.position = new(Random.Range(-(boundingBox.x / 2), boundingBox.x / 2) + transform.position.x, Random.Range(-(boundingBox.y / 2), boundingBox.y / 2) + transform.position.y, this.transform.position.z);
            gM.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
            gM.transform.rotation = new(0, 0, 0, 0);
            chipSpawnCount++;
        }
    }

    public void coinPoolCreation()
    {
        coinPreFab.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
        coinPreFab.transform.position = new Vector3(0, -30, 0);
        for (int i = 0; i < coinCount; i++)
        {
            GameObject peep = Instantiate(coinPreFab);
            peep.transform.position = new Vector3(0, -30, 0);
            peep.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
            peep.transform.parent = this.gameObject.transform;
        }
    }
    void coinPoolReset()
    {
        foreach (Transform child in transform)
        {
            child.transform.position = new Vector3(0, -30, 0);
            child.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
            child.transform.parent = this.gameObject.transform;
        }
    }

    public void coinSpawn()
    {
        //over time spawn each 
        chipSpawning = true;
        chipSpawnCount = 0;
    }

    public void OpenGateResetGate()
    {
        if(GateState) //true = open the gate
        {
            if (gateRight.transform.position != gateROpenPos.position)
            {
                //lerp from gateright to openpos
                gateRight.transform.position = Vector3.Lerp(rClosePos,gateROpenPos.position,i);
                gateLeft.transform.position = Vector3.Lerp(lClosePos, gateLOpenPos.position,i);
            }
            else
            {
                GateInAction = false;
                //wait acouple seconds reactivate
                waitTrue = true;
                w = 0;
                timer = speed * 2;
            }
        }
        else // false = close the gate 
        {
            if (gateRight.transform.position != rClosePos)
            {
                gateRight.transform.position = Vector3.Lerp(gateROpenPos.position, rClosePos, i);
                gateLeft.transform.position = Vector3.Lerp(gateLOpenPos.position, lClosePos, i);
            }
            else
            {
                GateInAction = false;
                coinPoolReset();
            }
        }
    }

}
