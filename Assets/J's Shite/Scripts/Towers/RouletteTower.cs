using JetBrains.Annotations;
using System.Collections;
using System.Threading;
using UnityEngine;

public class RouletteTower : MasterTowerScript
{
    /*public GameObject shootPoint;
    public GameObject bullet;*/
    public float shotInterval;
    private tower_FindTarget findTarget;
    //public Transform target;
    int i = 0;


    private void Start()
    {
        findTarget = GetComponent<tower_FindTarget>();
    }

    void FixedUpdate()
    {
        i++;

        if (findTarget.potentialTargets.Count > 0)
        {
            /*Vector3 targ = findTarget.Target.transform.position;
            targ.z = 0f;

            Vector3 objectPos = transform.position;
            targ.x = targ.x - objectPos.x;
            targ.y = targ.y - objectPos.y;

            float angle = Mathf.Atan2(targ.y, targ.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle - 90));*/

            if (i > shotInterval)
            {
                findTarget.sortList();
                i = 0;
            }


        }
    }
}
