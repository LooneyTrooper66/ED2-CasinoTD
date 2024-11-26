using JetBrains.Annotations;
using UnityEditor.Rendering;
using UnityEngine;

public interface MasterTowerScript
{
    /// <summary>
    /// shootin time
    /// </summary>
    /// <param name="target"></param>
    public void Shoot(GameObject target)
    {
        Debug.Log("shootin time");
    }
}
