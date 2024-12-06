using UnityEngine;

public class CardBulletBehaviour : MonoBehaviour
{
    private tower_FindTarget findTarget;
    public float shotInterval;
    int i = 0;


    void Start()
    {
        findTarget = GetComponent<tower_FindTarget>();
    }

    void FixedUpdate()
    {
        i++;

        if (findTarget.potentialTargets.Count > 0)
        {
            transform.LookAt(findTarget.Target.transform);

            if (i > shotInterval)
            {
                findTarget.sortList();
                i = 0;
            }
        }
    }
}
