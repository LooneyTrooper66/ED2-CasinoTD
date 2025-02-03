using UnityEngine;

public class HorseTower : MonoBehaviour
{
   [SerializeField] private enemy_Manager manager;
   // private tower_FindTarget findTarget;
    public float shotInterval;
    float i = 0;
    //create a list of the 2 proptery blocks :£
    MaterialPropertyBlock mpg;

    private void Start()
    {
        //findTarget = GetComponent<tower_FindTarget>();
        //GameObject temp = GameObject.Find("Wave_Control");
        //manager = temp.GetComponent<enemy_Manager>();

        manager = FindFirstObjectByType<enemy_Manager>();

        //get children
        foreach(Transform child in transform)
        {
            // get the shader and create a property block for it :3 
            child.GetComponent<SpriteRenderer>().SetPropertyBlock(mpg);
            //MaterialPropertyBlock mpg;
        }
    }

    private void FixedUpdate()
    {
        if (manager.waveState == enemy_Manager.WaveState.WaveActive ||manager.waveState == enemy_Manager.WaveState.WaveSpawning)
        {
            i += 1/50;
            //update property block :3
            mpg.SetFloat("Progress", i);
        }

       if (i > shotInterval )
        {
            i = 0;
            manager.SummonTest(0);

            //findTarget.sortList();
        }
    }
        
}
