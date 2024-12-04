using System;
using UnityEngine;
//using UnityEngine.WSA;

public class enemy_Move : MonoBehaviour
{
    public float Health;
    [Header("")]
    public int damage;
    public float speed;

    [HideInInspector]public int i; //needs to be public so it can use other scripts :3 but its ugly so we hide it :3
    [Header("Extras")] 
    public path_Genarator eM;
    public Vector2 goalPos;

    public bool inactive;
    public Rigidbody2D rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        // eM.NextPos(GetComponent<enemy_Move>());
        i = 0;
        eM = FindFirstObjectByType<path_Genarator>(); // this could be done during the spawning of the object instead of finding its much faster, very mindfull , very demure , in my lane thriving
        
        if (GameObject.FindGameObjectsWithTag("playerManager").Length > 1)
        {
            Debug.LogWarning("multiple playerManagers please remove one :3 , thank you");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(inactive) { return;}

        if (transform.position == new Vector3(goalPos.x,goalPos.y,transform.position.z))
        {
            PosDone();
            return;
        }
        rb.MovePosition(Vector3.MoveTowards(transform.position, goalPos, speed / 100));
        //Vector3 dir = new Vector3(goalPos.x,goalPos.y,transform.position.z) - transform.position;
        //transform.position = Vector3.MoveTowards(transform.position, goalPos, speed /50);  //doing this equation on every enemy could be costly so my other idea is making each point do the direction equation and then they only need to add their speed to total
    }

    public void PosDone()
    {
        if (i >= eM.RowConnectors.Count - 1)
        {
            //doeal damage to the players health
            //playerhealth.takedamage(damage);  <--- example code
            i= 0;
            inactive = true;
            Debug.Log("die");
            GameObject.FindWithTag("playerManager").GetComponent<HealthManager>().TakeDamage(damage);
            //parent it to wave manager :3 please
            Death();
            //call a enemy manager function to disable this and add it back into the enemy que
            //teleport the enemy offscreen and into storage
        }
        else
        {
            i++;
            goalPos = eM.RowConnectors[i];
        }
    }

    public void spawn()
    {
        i=0;
        transform.position = eM.RowConnectors[i];
        goalPos = eM.RowConnectors[i];
    }

    public void Hit(float Damage)
    {
        Health -= damage;
        //death check
        if (Health <= 0)
        {
            Death();
        }
    }

    public void Death()
    {
        //send to the shadow realm :3
        transform.SetParent(transform.parent.parent.GetChild(0));
        gameObject.SetActive(false);
    }


}
