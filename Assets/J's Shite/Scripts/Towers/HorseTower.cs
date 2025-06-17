using NUnit.Framework;
using UnityEngine;

public class HorseTower : MonoBehaviour
{
   [SerializeField] private enemy_Manager manager;
    public Transform childHolder;
   // private tower_FindTarget findTarget;
    public float shotInterval;
    [SerializeField]float i = 6;
    //create a list of the 2 proptery blocks :£
    MaterialPropertyBlock mpb;
    AudioSource audioM;


    private void Start()
    {
        //findTarget = GetComponent<tower_FindTarget>();
        //GameObject temp = GameObject.Find("Wave_Control");
        //manager = temp.GetComponent<enemy_Manager>();

        manager = FindFirstObjectByType<enemy_Manager>();
        mpb = new MaterialPropertyBlock();
        //get children
        foreach(Transform child in childHolder)
        {
            // get the shader and create a property block for it :3 
            child.GetComponent<SpriteRenderer>().SetPropertyBlock(mpb);
            mpb.SetFloat("Progress", 1);
        }

        audioM = GameObject.Find("PlayerManager").GetComponent<AudioSource>();
    }

    private void FixedUpdate()
    {
        if (manager.waveState == enemy_Manager.WaveState.WaveActive || manager.waveState == enemy_Manager.WaveState.WaveSpawning)
        {
            i += 1 * Time.deltaTime;
            //update property block :3
            //mpb.SetFloat("Progress", shotInterval/i);
            
        }
        foreach (Transform child in childHolder)
        {
            // get the shader and create a property block for it :3 
            child.gameObject.GetComponent<SpriteRenderer>().material.SetFloat("Progress",i / shotInterval);
        }
        if (i > shotInterval )
        {
            i = 0;
            manager.SummonTest(0);
            audioM.Play();

            //findTarget.sortList();
        }

        if (manager.waveState == enemy_Manager.WaveState.WaveClear)
        {
            audioM.Stop();
        }
    }
        
}
