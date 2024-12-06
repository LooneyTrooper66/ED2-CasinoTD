using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;


public class tower_FindTarget : MasterTowerScript
{
    public GameObject Target;
    public List<GameObject> potentialTargets;

    public GameObject shootPoint;
    public GameObject bullet;

    int tI;
    public TargetingOrder targeting;
    public enum TargetingOrder 
    {
        First,
        Strong,
        Close,
        Last
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        //check the positon on the path the collsions is ahead of where it current target is or if its speed is higher  
        if (collision.CompareTag("enemy") && !potentialTargets.Contains(collision.gameObject))
        {
            //check gameobjects  
            //get its current :3
            // sort the lift by position,-position,distance,targetpower+ 
            //set tartet to
            potentialTargets.Add(collision.gameObject);
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        //find gameobject in list and removeself
        //list.remove(collision)
        if (potentialTargets.Contains(collision.gameObject))
        {
            potentialTargets.Remove(collision.gameObject);
        }
    }

    public void sortList()
    {
        tI = -1; // set the target to -1 so enemys at point 0 can still be hit lol
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
                foreach (GameObject gO in potentialTargets)
                {
                    //if (gO == null) { return; } // a just in case mesure :3
                    if (gO.GetComponent<enemy_Move>().i > tI)
                    {
                        //greater then so replace
                        Target = gO;
                        tI = gO.GetComponent<enemy_Move>().i;
                    }
                    else if (gO.GetComponent<enemy_Move>().i == tI)
                    {
                        //do the equation check 
                        // get the postion of their next goal
                        //get the dist each object is from 
                        Vector3 goal = Target.GetComponent<enemy_Move>().goalPos;
                        float ttp = Vector2.Distance(Target.transform.position, goal); 
                        float got = Vector2.Distance(gO.transform.position, goal);
                        if (got <= ttp)
                        {
                            Target = gO;
                            tI = gO.GetComponent<enemy_Move>().i;
                        }
                    }
                        
                }


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
        Target = potentialTargets[0];
    }

    public void callAttack()
    {
        //base.Shoot(bullet, shootPoint);
    }
}
