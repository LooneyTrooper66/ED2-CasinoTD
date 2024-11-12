using System;
using UnityEngine;

public class path_Generator : MonoBehaviour
{
    public Transform start;
    public Transform end;
    public Transform[] beziaOffset;

    public LineRenderer lineRenderer;
    [Range(0,20)] public int reseloution;
    private Vector2[] lines;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GenerateCurve()
    {
        Debug.Log("meow");
        for (float i = 0; i <= 1; i+=(i / reseloution))
        {
            //do the bezia curve equation :3
            //i = time  resloution = the number of lines used 
        }
    }
}
