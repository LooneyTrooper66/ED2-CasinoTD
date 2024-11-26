using System;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class ProjectileBehaviour : MasterTowerScript
{
    public float speed = 20f;
    public float range;
    public Transform shootPoint;
    public Vector3 poolPoint;
    //private tower_FindTarget tft;
    public GameObject target;


    /*private void Start()
    {
        tft = GetComponentInParent<tower_FindTarget>();
    }*/

    void Update()
    {
        // Movement \\

        if (Vector2.Distance(gameObject.transform.position, shootPoint.position) <= range) // check the distance from the centre point here
        {
            gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, target.transform.position, 30 * Time.deltaTime);
        }
        else
        {
            gameObject.transform.position = poolPoint;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "enemy")
        {
            MoveBack(gameObject, poolPoint);
        }
    }
}
