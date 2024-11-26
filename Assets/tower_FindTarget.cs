using System.Collections.Generic;
using UnityEngine;

public class tower_FindTarget : MonoBehaviour
{
    public GameObject Target;
    public List<GameObject> potentialtargets;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //check the positon on the path the collsions is ahead of where it current target is or if its speed is higher  
        if (collision.tag == "enemy")
        {

        }
    }
}
