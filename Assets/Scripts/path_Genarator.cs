using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class path_Genarator : MonoBehaviour
{
    [Header("Position")]
    //public List<Transform> p;
    //private List<Vector3> pList;
    public List<Vector3> RowConnectors;
    //private Position P1 = p[0].position;
    //public Transform[]
    [Header("")]
    public Slot_Manager sM;
    // [Range(0, 1)] public float timer;

    [Header("")]
    public LineRenderer lineRenderer;
    public bool drawPath;
    public GameObject drawLine;
    public float timer;
    private int pathPoint;
    public float DrawSpeed;
    //[Range(0, 20)] public int reseloution;
    private Vector3 rCDueRemove;
    public enemy_Manager eM;
    private float rowOffset = 0.2f;
    //List <Vector3> a;
    //List <Vector3> b;
    public List<Sprite> lineSprites;
    /*  0 = straight X
        1 = straight Y
        2 = in turn up /// flip y for down
        3 = out turn // flip y or smt idkfc
    */

   // public bool gencurve;
    public bool clearCurve;

    // Start is called once before the first execution of Update after the MonoBehaviour is 
    void Start()
    {
        //getEnE();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (clearCurve)
        {
            clearCurve = false;
            ClearPath();
            //PathCreation();
            //timer = 0;
        }

        if (drawPath)
        {
            PathDraw();

        }

    }
    /// <summary>
    /// this will go on the slot host and connect every row together hopefully
    /// </summary>
    public void PathCreation()
    {
        //get the postions of every single 
        //row 1 start to row one end to row 2 start to end to row three start to row 3 end 
        //RowConnectors = sM.t;
        RowConnectors.Clear();
        foreach (RowRandomiser tr in sM.r)
        {
            // rcdueroemove + offset < && > rcdueromve - offset  
             if (Vector2.Distance(tr.rowEntrance.transform.position,rCDueRemove) >= rowOffset) // removes reduntant rows 
             {
                 RowConnectors.Add(tr.rowEntrance.transform.position);

             }
            //RowConnectors.Add(tr.rowEntrance.transform.position);
            RowConnectors.Add(tr.rowExit.transform.position);
            rCDueRemove = tr.rowExit.transform.position;
            //Debug.Log(tr.position);
        }
        lineRenderer.positionCount = 2;
        drawPath = true;
        drawLine.transform.position = RowConnectors[0];
        pathPoint = 1;
        lineRenderer.SetPosition(0, RowConnectors[0]);
        //lineRenderer.Simplify(0.4f);
        //replace this with a move pos to rowconnect.i and repeat that function untill all points have been reach its gonna be the same move script that the enenmys will follow 
        /*for (int i = 0; i <= RowConnectors.Count - 1; i++)
        {
            lineRenderer.SetPosition(i, RowConnectors[i]);

        }*/
    }

    public void PathDraw() //<-- i equals 
    {
        if (pathPoint == RowConnectors.Count) // ifits reached the final point
        {
            drawPath = false;
            lineRenderer.positionCount = (RowConnectors.Count);
            eM.summontest = true; // just for scott
            return;
        }


        //drawLine.transform.
        if (drawLine.transform.position == RowConnectors[pathPoint]) 
        {
            //check if its reached the end of the line and gets the next position on the list 
            lineRenderer.SetPosition(pathPoint, RowConnectors[pathPoint]); // set the postion off the point to its finalised postions
            pathPoint += 1;//update refrance int
            lineRenderer.positionCount++; //this makes a new postion in the list
           // Debug.Log(lineRenderer.positionCount);
            lineRenderer.SetPosition(pathPoint, drawLine.transform.position);
            //timer = 0;
            //get the type of sprite to use 
            //
            if (RowConnectors.Count != pathPoint)
            {
                Vector2 v2 = RowConnectors[pathPoint - 1] - RowConnectors[pathPoint];
                Vector2 v1 = RowConnectors[pathPoint - 2] - RowConnectors[pathPoint - 1];
                if (Mathf.Round(v1.x) == 0 || Mathf.Round(v2.x) == 0) // todo add the offset of 0.1 ish    this should be if the  connection is constant between 2 gates
                {
                    Instantiate(drawLine.gameObject).transform.position = RowConnectors[pathPoint - 1];
                }
                else
                {
                    //curve
                    //Instantiate(drawLine.gameObject).transform.position = RowConnectors[pathPoint - 1];
                    //set a bool to be true that makes the next straigh curved opposite to this one 
                    //or just check the past so get current next and past? but proble woulb be if their is no past 
                }
            }
        }
        else
        {
                                                        //pre point                       // current point 
            //drawLine.transform.position = Vector3.Lerp(RowConnectors[pathPoint - 1], RowConnectors[pathPoint], timer); //move the postion of 
            drawLine.transform.position = Vector3.MoveTowards(drawLine.transform.position, RowConnectors[pathPoint], DrawSpeed * Time.deltaTime);
            //lineRenderer.SetPosition(pathPoint, drawLine.transform.position);
            if (lineRenderer.positionCount >= pathPoint)
            {
                lineRenderer.SetPosition(pathPoint, drawLine.transform.position);
            }
            timer += DrawSpeed;
        }

        //if drawMethods
        /*
         Each type of gameobject will need its new method for drawing 
         if its a straight spawn it at the postion at last with a 0,1,1 scale and then move it to the center of the object and scale the object to size
         if its a corner piace do the same but dont scale the object instead 
          
         */
        //move drawline to pathpoint and move linerender[pathpoint]
    }

    public void ClearPath()
    {
        lineRenderer.positionCount = 2;
        lineRenderer.SetPosition(0, new(-10, -10, 0));
        lineRenderer.SetPosition(1, new(-10, -10, 0));
        //reset sprites 
    }
    
    //rowconnectors
    void drawSprites()//get the postions of both the 
    {
        // each row will either be one of 6ish arrays
        // this function will do alot of shit but howwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwww
        // get the state of the line 
        //       if its a straigh create the right type and lerp its postion from 1-2
        //       if its a curve find the last created brige piace spawn it under that and move it into the exit pos of the current row
        //
    }

   /* void GeneratePosOnCurve()
    {
        a.Clear();
        a.Add(Vector3.Lerp(p[0].position, p[1].position, timer));
        a.Add(Vector3.Lerp(p[1].position, p[2].position, timer));
        a.Add(Vector3.Lerp(p[2].position, p[3].position, timer));


        b.Clear();
        b.Add(Vector3.Lerp(a[0], a[1], timer));
        b.Add(Vector3.Lerp(a[1], a[2], timer));

        tester.transform.position = Vector3.Lerp(b[0], b[1], timer);
    }*/
   /* public void getEnE(List<RowRandomiser> lp)
     {
        for (int k = 0; k < sM.r.Count; k++)
        {
            RowConnectors.Add(lp[k].rowEntrance);
            RowConnectors.Add(lp[k].rowExit);
        }
        meow = lp;
        Debug.Log(meow[1]);
        lineRenderer.positionCount = RowConnectors.Count;

   }*/
   /*
   time to start on the new draw method? :3
   split the path into 2 parts
        - straights
        - turns
   create an array of options
   that array is created on the original array cration of the path
   each number would = the type of path
        - 1 straight horozontal 
        - 2 turn up
        - 3 turn down
        - 4 straight vertical
   how do i make the sprites draw tho?
        - sprite renders have a tool to fill smt with a radial version for the turns 
                - this method only works on image renders so i would have to make everthing in a cavas instead?
   
   example fakecode
        for i in points
            sprite = sprite.array[i]   --sets the sprite used in the g
            draw da sprite somehow
            if its a bend sprite use the image render to fill at a 90dagreese anlge so it draws
            other method just use the rotaated and use normal fill

    i think i gonna use a world space overlay for this now 
   
   
   */
}
