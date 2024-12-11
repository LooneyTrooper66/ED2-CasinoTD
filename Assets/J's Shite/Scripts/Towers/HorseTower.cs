using UnityEngine;

public class HorseTower : MonoBehaviour
{
    private enemy_Manager manager;
    private tower_FindTarget findTarget;
    public float shotInterval;
    float i = 0;


    private void Start()
    {
        findTarget = GetComponent<tower_FindTarget>();
        GameObject temp = GameObject.Find("Wave_Control");
        manager = temp.GetComponent<enemy_Manager>();
    }

    private void FixedUpdate()
    {
        i += 1 * Time.deltaTime;

        if (findTarget.potentialTargets.Count > 0)
        {
            findTarget.sortList();
            if (findTarget.Target != null)
            {
                if (i > shotInterval)
                {
                    i = 0;
                    manager.SummonTest(0);

                    findTarget.sortList();
                }
            }
        }
    }
}
