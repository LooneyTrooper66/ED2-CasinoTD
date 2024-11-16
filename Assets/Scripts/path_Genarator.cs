using System.Collections.Generic;
using UnityEngine;

public class path_Genarator : MonoBehaviour
{
    [Header("Position")]
    //public List<Transform> p;
    //private List<Vector3> pList;
    public List<Transform> RowConnectors;
    //private Position P1 = p[0].position;
    //public Transform[]
    [Header("")]
    public GameObject tester;
    public Slot_Manager sM;
   // [Range(0, 1)] public float timer;

    [Header("")]
    public LineRenderer lineRenderer;
    //[Range(0, 20)] public int reseloution;

    //List <Vector3> a;
    //List <Vector3> b;


    public bool gencurve;

    // Start is called once before the first execution of Update after the MonoBehaviour is 
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (gencurve)
        {
            gencurve = false;
            PathCreation();
            //timer = 0;
        }

/*        if (timer <= 1)
        {
            timer += Time.deltaTime;
        }
        else
        {
            timer = 0;
        }*/
    }
    /// <summary>
    /// this will go on the slot host and connect every row together hopefully
    /// </summary>
    public void PathCreation()
    {
        //get the postions of every single 
        //row 1 start to row one end to row 2 start to end to row three start to row 3 end 
        for (int i = 0 ; i <= RowConnectors.Count - 1 ; i++)
        {
                lineRenderer.SetPosition(i, RowConnectors[i].position);
        }
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
     public void getEnE()
     {
        RowConnectors.Clear();
        for (int k = 0; k < sM.r.Count; k++)
        {
            RowConnectors.Add(sM.r[k].rowEntrance);
            RowConnectors.Add(sM.r[k].rowExit);
        }
        lineRenderer.positionCount = RowConnectors.Count;

   }
}
