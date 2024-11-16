using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Slot_Manager : MonoBehaviour
{
    //public RowRandomiser r1; <-- reminants of a older time
    //public RowRandomiser r2;
    //public RowRandomiser r3;

    public List<RowRandomiser> r; // <-- the hip new list method thats so much cooler (i have been using to many lists in this code please god help me)
   // public List<Transform> t;
    [HideInInspector] public int rowNumb;
    public path_Genarator pG;

    public List<int> rowOutPut;

    public bool reset;
    public bool stop;
    public bool rigged; //this can be used for forced results no use yet

    // Start is called before the first frame update
    void Awake()
    {
        int wow = 0;
        //r.Add(GetComponentInChildren<RowRandomiser>());
        foreach (Transform child in transform)
        { 
            r.Add(child.GetComponent<RowRandomiser>());
           // t.Add(r[wow].rowEntrance);
           // t.Add(r[wow].rowExit);
            wow++;
        }
        
    }


    // Update is called once per frame
    void Update()
    {
        if (reset)
        {
            reset = false;
            rowOutPut.Clear();
            rowNumb = 0;
           /* r1.VauleRest();
            r2.VauleRest();
            r3.VauleRest();*/
            foreach (RowRandomiser o in r)
            {
                o.VauleRest();
            }
        }
        if(stop)
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
            Debug.Log("JackpotCheck");
        }

    }

    public void nextRow(int me)
    {
        rowNumb++;
        r[rowNumb].lastRoll = true;
        rowOutPut.Add(me);
    }
}
