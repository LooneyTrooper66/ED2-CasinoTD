using JetBrains.Annotations;
using System.Collections;
using UnityEditor.Rendering;
using UnityEngine;

public class MasterTowerScript : MonoBehaviour
{
    /// <summary>
    /// shootin time
    /// </summary>
    /// <param name="target"></param>
    public virtual void Shoot(GameObject[] bullet, GameObject shootPoint, float fireRate)
    {
        for (int i = 0; i < bullet.Length;)
        {
            bullet[i].transform.position = shootPoint.transform.position;

            StartCoroutine(NextBullet(i, fireRate));
        }
    }

    IEnumerator NextBullet(int i, float fireRate)
    {
        yield return new WaitForSeconds(fireRate);
        i++;
        yield return null;
    }

    /// <summary>
    /// return the towers projectile to the pool point
    /// </summary>
    public virtual void MoveBack(GameObject projectile, Vector3 spawnPoint)
    {
        projectile.transform.position = spawnPoint;
    }
}
