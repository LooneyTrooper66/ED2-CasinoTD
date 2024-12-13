using System.Collections.Generic;
using UnityEditor;
using UnityEngine;


public class tower_FindTarget : MonoBehaviour
{
    public GameObject Target;
    public List<GameObject> potentialtargets;

    public TargetingOrder targeting;
    public enum TargetingOrder 
    {
        First,
        Strong,
        Close,
        Last
    }
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
            //check gameobjects  
            //get its current :3
            // sort the lift by position,-position,distance,targetpower+ 
            //set tartet to
            potentialtargets.Add(collision.gameObject);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        //find gameobject in list and removeself
        //list.remove(collision)
        if (potentialtargets.Contains(collision.gameObject))
        {
            potentialtargets.Remove(collision.gameObject);
        }
    }

    public void sortList()
    {
        //Dont think we will be able to add diffrent type of fireing methods
        switch (targeting)
        {
            case TargetingOrder.First:
                //sorts the list in position decending it :(

                //list untored into sorted list/ clear unsotred list 
                //sort by enemy i stat then sort all equal i then sort by distance from current goal pos? this is gonna be so inneffeciant 3 what if i s

                //sort list by i
                //sort list by x+y vaule who evers is grate goes infront 

                //for each gameobject in list do the loop
                break;
            case TargetingOrder.Strong: //<-- this is where i would put other sorting algorytms if i had any!!!!!!!!!!!!!!!!!
                // sorts list by enemy class difficuly
                targeting = TargetingOrder.First;
                sortList();
                break;
            case TargetingOrder.Close:
                //find closets enemy
                targeting = TargetingOrder.First;
                sortList();
                break;
            case TargetingOrder.Last:
                //sorts the list in postions 
                targeting = TargetingOrder.First;
                sortList();
                break;
        }
        Target = potentialtargets[0];
    }

    public void callAttack()
    {
        //shoot(target) do we add attack cooldown here or later?
    }
}
