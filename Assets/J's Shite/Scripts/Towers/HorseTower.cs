using UnityEngine;

public class HorseTower : MonoBehaviour
{
   [SerializeField] private enemy_Manager manager;
   // private tower_FindTarget findTarget;
    public float shotInterval;
    float i = 0;


    private void Start()
    {
        //findTarget = GetComponent<tower_FindTarget>();
        //GameObject temp = GameObject.Find("Wave_Control");
        //manager = temp.GetComponent<enemy_Manager>();

        manager = FindFirstObjectByType<enemy_Manager>();
    }

    private void FixedUpdate()
    {
        if (manager.waveState == enemy_Manager.WaveState.WaveActive ||manager.waveState == enemy_Manager.WaveState.WaveSpawning)
        {
            i += 1 * Time.deltaTime;
        }

       if (i > shotInterval )
        {
            i = 0;
            manager.SummonTest(0);

            //findTarget.sortList();
        }
    }
        
}
