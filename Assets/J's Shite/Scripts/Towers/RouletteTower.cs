using JetBrains.Annotations;
using System.Collections;
using System.Threading;
using UnityEngine;

public class RouletteTower : MasterTowerScript
{
    //public GameObject shootPoint;
    public GameObject bullet;
    public float shotInterval;
    private tower_FindTarget findTarget;
    //public Transform target;
    int i = 0;
    public float ballDistFromCener;
    public Vector3 ballpos;

    private void Start()
    {
        findTarget = GetComponent<tower_FindTarget>();
        ballDistFromCener = Vector3.Distance(transform.position, bullet.transform.position);
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

                Vector3 dir = findTarget.Target.transform.position - transform.position;
                ballpos = new(dir.y, -dir.x);
                ballpos.Normalize();
                ballpos = new (ballpos.x + transform.position.x, ballpos.y + transform.position.y);
                Vector2 ballDir = findTarget.Target.transform.position - ballpos;
                //instanciate ball and give it direction
                GameObject bt =Instantiate(bullet);
                bt.transform.localPosition = ballpos;
                bt.GetComponent<ProjectileBehaviour>().Spawn(ballDir);
            }




        }
    }
}
