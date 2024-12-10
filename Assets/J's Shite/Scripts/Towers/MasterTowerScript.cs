using JetBrains.Annotations;
using System.Collections;
using UnityEngine;

public class MasterTowerScript : MonoBehaviour
{
    /// <summary>
    /// shootin time
    /// </summary>
    /// <param name="bullet, shootpoint"></param>
    public virtual void Shoot(GameObject bullet, GameObject shootPoint)
    {        
        Instantiate(bullet, shootPoint.transform.position, shootPoint.transform.rotation);
       // Debug.Log("run instans");
        //tF.sortList(); // program crashes out before can run next debug, so assuming this line is the issue
        //Debug.Log("run sortList");
    }
}
