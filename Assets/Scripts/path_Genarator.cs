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
            if (Vector2.Distance(tr.rowEntrance.transform.position,rCDueRemove) >= rowOffset)
            {
                RowConnectors.Add(tr.rowEntrance.transform.position);

            }
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
            return;
        }


        //drawLine.transform.
        if (timer >= 1)
        {
            lineRenderer.SetPosition(pathPoint, RowConnectors[pathPoint]);
            pathPoint += 1;
            lineRenderer.positionCount++;
            lineRenderer.SetPosition(pathPoint, drawLine.transform.position);
            timer = 0;
        }
        else
        {
            drawLine.transform.position = Vector3.Lerp(RowConnectors[pathPoint - 1], RowConnectors[pathPoint], timer); //move the postion of 
            //lineRenderer.SetPosition(pathPoint, drawLine.transform.position);
            if (lineRenderer.positionCount >= pathPoint)
            {
                lineRenderer.SetPosition(pathPoint, drawLine.transform.position);
            }
            timer += DrawSpeed;
        }
        //move drawline to pathpoint and move linerender[pathpoint]
    }

    public void ClearPath()
    {
        lineRenderer.positionCount = 2;
        lineRenderer.SetPosition(0, new(-10, -10, 0));
        lineRenderer.SetPosition(1, new(-10, -10, 0));
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
