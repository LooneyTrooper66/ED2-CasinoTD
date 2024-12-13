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

    public List<GameObject> enemyVault;
    public Enemy_Stats[] enemyVariaints; 

    


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
            testEnemy.spawn();
        }
    }
    /// <summary>
    /// spawn a single enemy
    /// </summary
    void summonTest()
    {

    }

    public void SummonWave()
    {

    }

    public void WaveClear()
    {

    }
}
