using JetBrains.Annotations;
using System.Collections;
using System.Threading;
using UnityEngine;

public class RouletteTower : MasterTowerScript
{
    public GameObject shootPoint;
    public GameObject bullet;
    public float shotInterval;
    public Transform target;
    int i = 0;


    void FixedUpdate()
    {
        if (target != null)
        {
            Vector3 targ = target.transform.position;
            targ.z = 0f;

            Vector3 objectPos = transform.position;
            targ.x = targ.x - objectPos.x;
            targ.y = targ.y - objectPos.y;

            float angle = Mathf.Atan2(targ.y, targ.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle - 90));

            i++;
            if (i > shotInterval)
            {
                base.Shoot(bullet, shootPoint);
                i = 0;
            }
        }
    }
}
