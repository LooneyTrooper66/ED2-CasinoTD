using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UIElements;

public class path_Generator : MonoBehaviour
{
    [Header("Position")]
    public List<Transform> p;
    private List<Vector3> pList;
    //private Position P1 = p[0].position;
    //public Transform[]
    [Header ("")]
    public GameObject tester;
    [Range(0, 1)] public float timer;

    [Header("")]
    public LineRenderer lineRenderer;
    [Range(0,20)] public int reseloution;
    private Vector2[] lines;

    Vector3 a;
    Vector3 b;
    Vector3 A;

    public bool gencurve;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gencurve)
        {
            gencurve = false;
            timer = 0;
        }

        if (timer <= 1)
        {
            GeneratePosOnCurve();
            timer += Time.deltaTime;
        }
        else
        {
            timer = 0;
        }
    }

    public void GenerateCurve()
    {
        Debug.Log("meow");
        Vector3 a;
        Vector3 b;
        Vector3 A;
        for (int i = 0; i/reseloution <= 1; i+= i)
        {
            //do the bezia curve equation :3
            //i = timerr  resloution = the number of lines used 
            //for i in range of p (number of points)
            //for i of range of the number of cubait lines inbatween the 2 points 
            //the final loop (might mkae this a funcion so i can make this loop as far as a i need 
            //Mathf.Lerp(p[o].transform.position.x, p[o+1].transform.position.x, i);
            //three point curve is just 2 lerps to give a and b then a lerp between a + b = c
            //4 point would be a + b =1 , b + c  =2 c + d =3 then useing the 3 numbers you lerp lerp 1,2 = a1 2 3 a2 then finnaly lerping a1 to a2 :3 
            a = Vector3.Lerp(p[0].position, p[1].position, i/reseloution);
            b = Vector3.Lerp(p[1].position, p[2].position, i/reseloution);
            A = Vector3.Lerp(a, b, i / reseloution);
        }
    }


    public void GeneratePosOnCurve()
    {

        for (int o = 0; o > p.Count - 1; o++)
        {
            a = Vector3.Lerp(p[o].position, p[o + 1].position, timer);
            pList.Add(a); 
        }
    }

}
