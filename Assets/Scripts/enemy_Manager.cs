using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class enemy_Manager : MonoBehaviour
{
    //public path_Genarator genarator;

    //this script will store all needed enemys and print them out as needed

    //create a array of all enemy types <-- these will be a scriptable objec with information needed and a interface for all the diffren quirks
    //waves could be a dicionary of <enemy type> <spawn delay> <batch size> (this could be a vector 3, each one represents the data needed )

    //private int etp;
    public bool EndlessDeactite; //true off  
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

    public GameObject waveClearPopup;
    public WaveState waveState;
    private int waveCount = 1;
    public Text waveText;

    public enum WaveState
    {
        WaveSpawning,
        WaveActive,
        WaveClear,
        WaveStart
    }

    private void Start()
    {
        waveClearPopup.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (summontest && waveState == WaveState.WaveStart) //debug
        {
            summontest = false;
            SummonWave();
        }
        if (waveState == WaveState.WaveClear && FinalWave)
        {
            slot.whichAnim = "pullFinal"; //set the lever to the cash out version!!!!            
            FinalWave = false;
        }

        //if active wave exisist and is empty and the timer is over the delay 
        if (activeWave != null && activeWave.Count() > 0 && timer >= delay)
        {
            SummonTest(Mathf.FloorToInt(activeWave[0].x));//floor to int so i make sure the vector is an int (could have used vector 2 ints )
            delay = (activeWave[0] == null)?  0 :  activeWave[0].y; 
            timer = 0;
            activeWave.RemoveAt(0);
            waveState = (activeWave.Count() == 0) ? WaveState.WaveActive : WaveState.WaveSpawning;
        }
        else if (active_Enemy.transform.childCount <= 0 && waveState == WaveState.WaveActive) // if the wave is active and no enemy are left alive
        {
            // is not spawning a wave check if the their are any enemts in the active enemy 
            //
            waveState = WaveState.WaveClear;
            StartCoroutine(UIPopUp(2)); //wave clear

            waveCount++;
            string waveStr = waveCount.ToString();
            waveText.text = $"Wave: {waveStr}";

            FinalWave = (waveTracker + 1 == waves.Length) ? true : false;
        }

        if (waveState == WaveState.WaveClear && waveTracker == waves.Length)
        {
            // im being lazy, il fix this later
            Debug.Log("ACTIVATE ENDLESS MODE");
            if (EndlessDeactite)
            {
                SceneManager.LoadScene("WinScreen");
            }     // UPDATE THIS FOR ENDLESS
            //activate endless mode
        }
    }
    /// <summary>
    /// spawn a single enemy based on the etp vaule 
    /// i forgot what etp means but sounds cool so i kept it
    /// </summary
    public void SummonTest(int etp)
    {
        if (transform.childCount <= 0)
        {
            selectedEnemy = Instantiate(EnemyBaseforInstanciating);
        }
        else
        {
            selectedEnemy = transform.GetChild(0).gameObject;
        }

        //set the gameObject Needed Information
        //change the enemy transfrom into the active zone
        selectedEnemy.SetActive(true);
        SEM = selectedEnemy.GetComponent<enemy_Move>();
        //set the Enemy Move 
        selectedEnemy.transform.parent = enemyTypes[etp].horse ? null : active_Enemy;
        selectedEnemy.tag = enemyTypes[etp].horse ? "tower" : "enemy";
        selectedEnemy.name = enemyTypes[etp].name;
        selectedEnemy.layer = enemyTypes[etp].horse ? 7 : 6;
        selectedEnemy.GetComponent<Collider2D>().isTrigger = enemyTypes[etp].horse ? true : false; ;
        SEM.Health = enemyTypes[etp].health;
        SEM.speed = enemyTypes[etp].speed * 2;
        SEM.damage = enemyTypes[etp].damage;
        SEM.Vaule = enemyTypes[etp].Vaule;
        SEM.goalPos = enemyTypes[etp].horse ? SEM.eM.RowConnectors.Last() : SEM.eM.RowConnectors[0];
        SEM.horse = enemyTypes[etp].horse;
        SEM.deathCoins = enemyTypes[etp].deathCoins;
        SEM.transform.rotation = Quaternion.Euler(0,0,enemyTypes[etp].horse? 90: SEM.transform.rotation.z);
        SEM.GetComponent<SpriteRenderer>().sprite = enemyTypes[etp].sprite;
        //will also need to add the objects animators
        SEM.inactive = false;
        SEM.i = 0;

        selectedEnemy.transform.position = enemyTypes[etp].horse ? SEM.eM.RowConnectors.Last() :SEM.eM.RowConnectors[0] + Vector3.left * 3;
    }

    public void SummonWave()
    {
        if (waveTracker < waves.Count())
        {
            activeWave = waves[waveTracker].enemies.ToList();
            waveTracker++;
            //FinalWave = (waveTracker + 1 == waves.Length) ? true : false;
            delay = 3 * Time.timeScale; // wave countdown
        }
        else
        {
            Debug.Log("ACTIVATE ENDLESS MODE");
            if (EndlessDeactite)
            {
                SceneManager.LoadScene("WinScreen");
            }     // UPDATE THIS FOR ENDLESS
            else
            {
                endlessStuff();
                waveTracker++;
                //FinalWave = (waveTracker + 1 == waves.Length) ? true : false;
                delay = 3 * Time.timeScale; // wave countdown
            }
            //activate endless mode
        }
    }

    public struct EnemyBatch
    {
        public int Count;//how many spawns before selecing the next batch
        public int Volume; //how many spaws in a batch such has a horse of 5
        public float countGap; // time betwwen batches
        public float VolumGap; // each volumes spacing 
        public int enemyType; // the spawning enemy 
    }

    void endlessStuff()
    {
        //activeWave
        List<Vector2> wave = new();
        float baseDifficultyPerWave = 1;
        float Aev = waveCount * baseDifficultyPerWave; ///Aev abiitary EnemeyValue

        EnemyBatch Batch;

        for (int i = 0; i < Aev;)
        {
           
                int type = Random.RandomRange(0, 5); //batch type
                int EnemyType = Random.RandomRange(1, 3); //enemey
                float typecost = 0;
                //get a fracion of the Aev left in the wave
                //aslo get the time the wave currently is 
              //  aev

                //Aev - i  = reming Aev in the wave

                Batch.Count = Random.RandomRange(2, 4);
                Batch.countGap = 0.5f;
                switch (type)
                {
                    case 0: //constant
                        Batch.Volume = 1;
                        Batch.VolumGap = 0.6f; //low count gap 2
                        Batch.enemyType = EnemyType;
                    typecost = 1;
                        break;
                    case 1: //rapid burst 
                        Batch.Volume = 3;
                        Batch.VolumGap = 0.1f;
                        Batch.enemyType = EnemyType;
                        Batch.Count *= 10;
                    typecost = 5;
                    break;
                    case 2: //spaced burst
                        Batch.Volume = 6 ;
                        Batch.VolumGap = 0.2f;
                        Batch.enemyType = EnemyType;
                        Batch.Count *= 3;
                    typecost = 3;
                    break;
                    case 3: //hord  //larg spaced birst
                        Batch.Volume = 12;
                        Batch.VolumGap = 0.3f;
                        Batch.enemyType = EnemyType;
                    typecost = 6;
                    break;
                    case 4: //spaced //large amounts of spaced
                        Batch.Volume = 2;
                        Batch.VolumGap = 0.2f;
                        Batch.enemyType = EnemyType;
                    typecost = 1;
                    break;
                    default:
                        Batch.Volume = 1;
                        Batch.VolumGap = 0.6f; //low count gap 2
                        Batch.enemyType = type;
                    typecost = 1;
                    break;
                }
            //now we have the batch we just create a new wave and loop through the batch

                i += (int)((typecost + EnemyType -1) * Batch.Count); 


                for (int o = 0; o < Batch.Count; o++)
                {
                    //add one batch of creatures
                    //wave.Add()
                    wave.Add(new Vector2(EnemyType, Batch.countGap));
                    for (int b = 0; b < Batch.Volume; b++)
                    {
                        wave.Add(new Vector2(EnemyType, Batch.VolumGap));
                    }
                }

        }
        activeWave = wave;
    }

    IEnumerator UIPopUp(int waitSecs)
    {
        waveClearPopup.SetActive(true);
        yield return new WaitForSecondsRealtime(waitSecs);
        waveClearPopup.SetActive(false);
    }

    //ENDLESS MODE ------
    //when the last wave is called instead change to endless mode 
    //endless modes last around 2 minites each? 
 

}

[System.Serializable]
public class Wave
{
    public Vector2[] enemies;
}
