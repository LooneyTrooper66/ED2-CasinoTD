using NUnit.Framework;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class enemy_Manager : MonoBehaviour
{
    //public path_Genarator genarator;

    //this script will store all needed enemys and print them out as needed

    //create a array of all enemy types <-- these will be a scriptable objec with information needed and a interface for all the diffren quirks
    //waves could be a dicionary of <enemy type> <spawn delay> <batch size> (this could be a vector 3, each one represents the data needed )


    public bool summontest;
    public enemy_Move testEnemy;

    public enemy_S_Obj[] enemyTypes; // this is better version as it only stores new data in each and as everything else is :3
    //public List<GameObject> enemyVault; replace this with parenting the object under the wave manager
    public path_Genarator pG;
    public Transform active_Enemy;
    private GameObject selectedEnemy;
    private enemy_Move SEM;

    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (summontest)
        {
            summontest = false;
            //summonTest();
            //testEnemy.spawn();
            SummonTest();
        }
    }
    /// <summary>
    /// spawn a single enemy or not 
    /// </summary
    void SummonTest()
    {
        ////...,.,//../...,.kljhniouhijoiyguhob uyog.
        if (transform.childCount < 0)
        {
            //spawn new enemy
            //selectedEnemy = Instantiate
        }
        else
        {
            selectedEnemy = transform.GetChild(0).gameObject;  // <-- get the first child
        }

        //set the gameObject Needed Information
        //change the enemy transfrom into the active zone
        selectedEnemy.transform.parent = active_Enemy;
        SEM = selectedEnemy.GetComponent<enemy_Move>();
        //set the Enemy Move 
        SEM.Health = enemyTypes[1].health;
        SEM.speed = enemyTypes[1].speed;
        SEM.damage = enemyTypes[1].damage;
    }

    public void SummonWave()
    {
        //grab any enemy in the vault
        //if vault is empty create a new base
        //set the base enemy to the correct enemy type
        // enemy_move.em = pg;
        //
    }

    public void WaveClear()
    {
        // once the number of enemys in the vault = spawned enemys the wave should be cleared
        // set all the enemys to disable and all that jazz so they cant fuck it up
    }
}
