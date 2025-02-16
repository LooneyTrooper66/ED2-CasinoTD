using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class Slot_Manager : MonoBehaviour
{
    //public RowRandomiser r1; <-- reminants of a older time
    //public RowRandomiser r2;
    //public RowRandomiser r3;

    public ChipForCash chips;
    public List<RowRandomiser> r; // <-- the hip new list method thats so much cooler (i have been using to many lists in this code please god help me)
   // public List<Transform> t;
    [HideInInspector] public int rowNumb;
    public path_Genarator pG;

    public List<int> rowOutPut;

    public Button pullToStart;
    public Animator buttonAnim;
    public ChipForCash cfc;

    [HideInInspector] public string whichAnim = "clicked";
    public bool reset;
    public bool stop;
    public bool rigged; //this can be used for forced results no use yet

    public ParticalManaher pm;
    [SerializeField] private enemy_Manager eM;
    // Start is called before the first frame update
    void Awake()
    {
        int wow = 0;
        //r.Add(GetComponentInChildren<RowRandomiser>());
        foreach (Transform child in transform)
        { 
            if(child.GetComponent<RowRandomiser>() != null)
            {
                r.Add(child.GetComponent<RowRandomiser>());
                // t.Add(r[wow].rowEntrance);
                // t.Add(r[wow].rowExit);
                wow++;
            }

        }

        pullToStart.onClick.AddListener(PullToStart);
    }


    // Update is called once per frame
    void Update()
    {
        if (reset)
        {
            reset = false;
            chips.tradableChipsThisRound = 3;
            rowOutPut.Clear();
            rowNumb = 0;
           /* r1.VauleRest();
            r2.VauleRest();
            r3.VauleRest();*/
            pG.ClearPath();
            foreach (RowRandomiser o in r)
            {
                o.VauleRest();
            }

            StartCoroutine(TimerForStop());
        }
        if(stop || Input.GetKeyDown(KeyCode.Space))
        {
            stop = false;
            //r1.lastRoll = true;
            r[0].lastRoll = true;
        }
    }

    public void JackpotCheck()
    {
        pG.PathCreation();
        rowOutPut.Sort();
        if (rowOutPut.First() == rowOutPut.Last())
        {
            pm.startP();
        }

    }

    public void nextRow(int me)
    {
        rowNumb++;
        r[rowNumb].lastRoll = true;
        rowOutPut.Add(me);
    }

    public void PullToStart()
    {
        if (eM.waveState == enemy_Manager.WaveState.WaveClear)
        {
            reset = true;
            buttonAnim.SetTrigger(whichAnim);
            //Handheld.Vibrate();

            // will flag an error, just ignore it coz unity is being a pain in the ass \\
            if (FindAnyObjectByType<enemy_Move>())
            {
                enemy_Move[] gmObj = FindObjectsOfType<enemy_Move>();
                foreach (var enOBJ in gmObj)
                {
                    Destroy(enOBJ.gameObject);
                }
                cfc.tradableChipsThisRound = 3;

                eM.waveState = enemy_Manager.WaveState.WaveStart;
            }
         
        }
    }

    IEnumerator TimerForStop()
    {
        yield return new WaitForSecondsRealtime(2);
        stop = true;
        StopCoroutine(TimerForStop());

    }
}
