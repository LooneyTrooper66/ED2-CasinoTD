using JetBrains.Annotations;
using System.Collections;
using UnityEditor.Rendering;
using UnityEngine;

public class MasterTowerScript : MonoBehaviour
{
    private tower_FindTarget tF;


    private void Start()
    {
        tF = GetComponent<tower_FindTarget>();
    }

    /// <summary>
    /// shootin time
    /// </summary>
    /// <param name="bullet, shootpoint"></param>
    public virtual void Shoot(GameObject bullet, GameObject shootPoint)
    {
        Instantiate(bullet, shootPoint.transform.position, shootPoint.transform.rotation);
        tF.sortList();
    }
}
