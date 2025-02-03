using UnityEngine;

public class HorseTower : MonoBehaviour
{
   [SerializeField] private enemy_Manager manager;
   // private tower_FindTarget findTarget;
    public float shotInterval;
    float i = 0;
    //create a list of the 2 proptery blocks :£
    MaterialPropertyBlock mpb;
    private void Start()
    {
        //findTarget = GetComponent<tower_FindTarget>();
        //GameObject temp = GameObject.Find("Wave_Control");
        //manager = temp.GetComponent<enemy_Manager>();

        manager = FindFirstObjectByType<enemy_Manager>();
        mpb = new MaterialPropertyBlock();
        //get children
        foreach(Transform child in transform)
        {
            // get the shader and create a property block for it :3 
            child.GetComponent<SpriteRenderer>().SetPropertyBlock(mpb);
            mpb.SetFloat("Progress", shotInterval / i);
            Debug.Log(child.gameObject.name);
            //MaterialPropertyBlock mpg;
        }
    }

    private void FixedUpdate()
    {
        if (manager.waveState == enemy_Manager.WaveState.WaveActive ||manager.waveState == enemy_Manager.WaveState.WaveSpawning)
        {
            i += 1 * Time.deltaTime;
            //update property block :3
            mpb.SetFloat("Progress", shotInterval/i);
        }

       if (i > shotInterval )
        {
            i = 0;
            manager.SummonTest(0);

            //findTarget.sortList();
        }
    }
        
}
