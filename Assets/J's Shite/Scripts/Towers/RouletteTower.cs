using JetBrains.Annotations;
using UnityEngine;

public class RouletteTower : MasterTowerScript
{
    public float Range; // <-- radius of circle cast
    //public tower_FindTarget tft;
    public GameObject target;
    public GameObject[] bullets;
    public GameObject shootPoint;
    public float fireRate;


    private void Update()
    {
        base.Shoot(bullets, shootPoint, fireRate);

        /*if (target) // <-- also check the upgrade level to determine the number of bullets to use
        {
            base.Shoot(bullets, shootPoint, fireRate);
        }*/
    }
}
