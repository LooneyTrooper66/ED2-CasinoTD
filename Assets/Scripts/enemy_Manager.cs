using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class enemy_Manager : MonoBehaviour
{
    //public path_Genarator genarator;

    //this script will store all needed enemys and print them out as needed

    //create a array of all enemy types <-- these will be a scriptable objec with information needed and a interface for all the diffren quirks
    //waves could be a dicionary of <enemy type> <spawn delay> <batch size> (this could be a vector 3, each one represents the data needed )

    //private int etp;
    public bool summontest;
    public GameObject EnemyBaseforInstanciating;

    public enemy_S_Obj[] enemyTypes; // this is better version as it only stores new data in each and as everything else is :3
    //public List<GameObject> enemyVault; replace this with parenting the object under the wave manager

    public path_Genarator pG;
    public Transform active_Enemy;
    private GameObject selectedEnemy;
    private enemy_Move SEM;

    public Wave[] waves;
    public int waveTracker;
    public bool waveInProgress;

    public Wave[] wildCardWave;

    [SerializeField] private List<Vector2> activeWave;
    private float timer;
    private float delay;

    public bool FinalWave;
    public Slot_Manager slot;

    public WaveState waveState;

    public enum WaveState
    {
        WaveSpawning,
        WaveActive,
        WaveClear,
        WaveStart
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (summontest && waveState == WaveState.WaveStart)
        {
            summontest = false;
            //summonTest();
            //testEnemy.spawn();
            SummonWave();
        }
        if (waveState == WaveState.WaveClear && FinalWave)
        {
            slot.whichAnim = "pullFinal"; //set the lever to the cash out version!!!!            
            FinalWave = false;
            // you only need to change the sprite, just make sure that pullFinal is called on the final round only so it doesnt look odd
        }


        if (activeWave != null && activeWave.Count() > 0 && timer >= delay)
        {
            //activeWave[0]
            SummonTest(Mathf.FloorToInt(activeWave[0].x));
            delay = (activeWave[0] == null)?  0 :  activeWave[0].y; 
           // waveState = (activeWave[0] == null)? WaveState.WaveActive : WaveState.WaveSpawning ;  // more enemys to spawn : no more enemeys to spawn
            timer = 0;

            activeWave.RemoveAt(0);
            waveState = (activeWave.Count() == 0) ? WaveState.WaveActive : WaveState.WaveSpawning;
        }
        else if (active_Enemy.transform.childCount <= 0 && waveState == WaveState.WaveActive)
        {
            // is not spawning a wave check if the their are any enemts in the active enemy 
            //
            waveState = WaveState.WaveClear;
            FinalWave = (waveTracker + 1 == waves.Length) ? true : false;

            // im being lazy, il fix this later
            Debug.Log("fucking die (you won)");
            Application.Quit();
        }
    }
    /// <summary>
    /// spawn a single enemy based on the etp vaule 
    /// i forgot what etp means but sounds cool so i kept it
    /// </summary
    void SummonTest(int etp)
    {
        ////...,.,//../...,.kljhniouhijoiyguhob uyog.
        if (transform.childCount <= 0)
        {
            //spawn new enemy
            //selectedEnemy = Instantiate
            selectedEnemy = Instantiate(EnemyBaseforInstanciating);
        }
        else
        {
            selectedEnemy = transform.GetChild(0).gameObject;  // <-- get the first child
        }

        //set the gameObject Needed Information
        //change the enemy transfrom into the active zone
        selectedEnemy.SetActive(true);
        selectedEnemy.transform.parent = SEM.horse?  null :active_Enemy;
        selectedEnemy.name = enemyTypes[etp].name;
        SEM = selectedEnemy.GetComponent<enemy_Move>();
        //set the Enemy Move 
        SEM.Health = enemyTypes[etp].health;
        SEM.speed = enemyTypes[etp].speed;
        SEM.damage = enemyTypes[etp].damage;
        SEM.Vaule = enemyTypes[etp].Vaule;
        SEM.goalPos = enemyTypes[etp].horse ? SEM.eM.RowConnectors.Last() : SEM.eM.RowConnectors[0];
        SEM.horse = enemyTypes[etp].horse;
        SEM.transform.rotation = Quaternion.Euler(0,0,enemyTypes[etp].horse? 90: SEM.transform.rotation.z);
        SEM.GetComponent<SpriteRenderer>().sprite = enemyTypes[etp].sprite;
        //will also need to add the objects animators
        SEM.inactive = false;
        SEM.i = 0;

        selectedEnemy.transform.position = enemyTypes[etp].horse ? SEM.eM.RowConnectors.Last() :SEM.eM.RowConnectors[0] + Vector3.left;
    }

    public void SummonWave()
    {
        //grab any enemy in the vault
        //if vault is empty create a new base
        //set the base enemy to the correct enemy type
        // enemy_move.em = pg;
        //
        //
        if (waveTracker < waves.Count())
        {
            activeWave = waves[waveTracker].enemies.ToList();
            waveTracker++;
            //FinalWave = (waveTracker + 1 == waves.Length) ? true : false;
            delay = 3; // wave countdown
        }
        else
        {
            // you won!!!!!!! maybe change the lever to a cash out button? 
            
        }
    }

    public void WaveClear()
    {
        // once the number of enemys in the vault = spawned enemys the wave should be cleared
        // set all the enemys to disable and all that jazz so they cant fuck it up

        //bag randomiser shite
       
    }
}

[System.Serializable]
public class Wave
{
    public Vector2[] enemies;
}
