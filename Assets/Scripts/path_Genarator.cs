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
    public GameObject LineHolder;
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
            eM.summontest = true; // just for scott <-- ok!
            //peanis - dont rememeber typing this even tho i just added this
            Draw_Straight(RowConnectors[pathPoint - 1], drawLine.transform.position);
            return;
        }


        //drawLine.transform.
        if (drawLine.transform.position == RowConnectors[pathPoint]) 
        {
            //check if its reached the end of the line and gets the next position on the list 
            lineRenderer.SetPosition(pathPoint, RowConnectors[pathPoint]); // set the postion off the point to its finalised postions
            pathPoint += 1;//update refrance int
            lineRenderer.positionCount++; 
            lineRenderer.SetPosition(pathPoint, drawLine.transform.position);
            if (RowConnectors.Count != pathPoint)
            {
                Vector2 v2 = RowConnectors[pathPoint - 1] - RowConnectors[pathPoint]; // the connevtionm between the currnet and next
                Vector2 v1 = RowConnectors[pathPoint - 2] - RowConnectors[pathPoint - 1]; // conntection between the current and prev 
                if (Mathf.Round(v1.x) == 0 || Mathf.Round(v2.x) == 0) 
                {
                    Draw_Turn(v1,v2);
                    //Draw_Straight(v1,v2);
                }
                else
                {
                    Draw_Connection();
                    //curve
                    //Instantiate(drawLine.gameObject).transform.position = RowConnectors[pathPoint - 1];
                    //set a bool to be true that makes the next straigh curved opposite to this one 
                    //or just check the past so get current next and past? but proble woulb be if their is no past 
                }
                Draw_Straight(v1, v2);
            }
        }
        else  // make this diffrent for each peaice then do the shiggy
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
    }

    //what information do we need? 
    /// <summary>
    /// fuck me i hate this code someone throw it into a fireeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeee
    /// </summary>
    /// <param name="v1"></param> connetion to previous point
    /// <param name="v2"></param> connetion to next point
    public void Draw_Turn(Vector2 v1 , Vector2 v2) // pass in the relevent information to tell if what parts of the sprite need ot be flipped or not
    {
        //create the object 
        GameObject pb = Instantiate(drawLine.gameObject);
        pb.transform.position = RowConnectors[pathPoint - 1];
        SpriteRenderer sp = pb.GetComponent<SpriteRenderer>();
        pb.GetComponent<SpriteRenderer>().enabled = true;
        pb.transform.parent = LineHolder.transform;
        //define its action
        if (Mathf.Round(v1.x) != 0) // the first curve
        {
            if (Mathf.Round(v2.y) >= 0) // down
            {
                sp.flipY = true;
            }
        }
        else
        {
            sp.flipX = true;
            if (Mathf.Round(v1.y) <= 0)
            {
                sp.flipY = true;
            }
        }
        pb.transform.localScale = new Vector3(1, 1, 1);
        sp.sortingOrder++;
    }
    //
    public void Draw_Straight(Vector2 v1,Vector2 v2)
    {
        GameObject pb = Instantiate(drawLine.gameObject);
        pb.transform.position = Vector2.Lerp(RowConnectors[pathPoint - 2], RowConnectors[pathPoint - 1],0.5f);//half way between both points :3
        SpriteRenderer sp = pb.GetComponent<SpriteRenderer>();
        pb.transform.parent = LineHolder.transform;
        sp.sprite = lineSprites[1];
        pb.GetComponent<SpriteRenderer>().enabled = true;
        if (MathF.Round(RowConnectors[pathPoint - 2].y) != Mathf.Round(RowConnectors[pathPoint - 1].y)) //we round beacuse 
        {
            pb.transform.Rotate(0, 0, 90, Space.Self);
        }
        pb.transform.localScale = new Vector3(Vector3.Distance(RowConnectors[pathPoint - 2], RowConnectors[pathPoint - 1]), 1, 1);
    }
    public void Draw_Connection()
    {
        GameObject pb = Instantiate(drawLine.gameObject);
        pb.transform.position = RowConnectors[pathPoint - 1];
        SpriteRenderer sp = pb.GetComponent<SpriteRenderer>();
        pb.transform.parent = LineHolder.transform;
        sp.sprite = lineSprites[1];
        pb.GetComponent<SpriteRenderer>().enabled = true;
        pb.transform.localScale = new(0.3f, 1, 1);
    }


    public void ClearPath()
    {
        lineRenderer.positionCount = 2;
        lineRenderer.SetPosition(0, new(-10, -10, 0));
        lineRenderer.SetPosition(1, new(-10, -10, 0));
        //reset sprites 
        foreach (Transform child in LineHolder.transform)
        {
            Destroy(child.gameObject);
        }
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
 
}
