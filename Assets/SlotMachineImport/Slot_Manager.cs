using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slot_Manager : MonoBehaviour
{
    public RowRandomiser r1;
    public RowRandomiser r2;
    public RowRandomiser r3;
    public path_Genarator pG;

    public bool reset;
    public bool stop;
    public bool rigged; //this can be used for forced results no use yet

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (reset)
        {
            reset = false;
            r1.VauleRest();
            r2.VauleRest();
            r3.VauleRest();
        }
        if(stop)
        {
            stop = false;
            r1.lastRoll = true;
        }
    }

    public void JackpotCheck()
    {
        pG.PathCreation();
        if (r1.rowhostint == r2.rowhostint && r2.rowhostint == r3.rowhostint)
        {
            //JackPot
            Debug.Log("JACKPOT");
            switch (r1.rowhostint)
            {
                case 0:
                    //testing
                    break;
                case 1:
                    //testing
                    break;
                case 2:
                    //testing
                    break;
                case 3:
                    //testing
                    break;

            }

        }
    }
}
