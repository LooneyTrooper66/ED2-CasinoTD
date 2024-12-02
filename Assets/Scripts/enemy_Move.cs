using UnityEngine;

public class enemy_Move : MonoBehaviour
{
    public int i;
    public path_Genarator eM;
    public Vector3 goalPos;
    public int damage;
    public float speed;
    public bool inactive;
    public Rigidbody2D rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // eM.NextPos(GetComponent<enemy_Move>());
        i = 0;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(inactive) { return;}

        if (transform.position == goalPos)
        {
            PosDone();
            return;
        }
        rb.MovePosition(Vector3.MoveTowards(transform.position, goalPos, speed /50));
        //transform.position = Vector3.MoveTowards(transform.position, goalPos, speed /50);  //doing this equation on every enemy could be costly so my other idea is making each point do the direction equation and then they only need to add their speed to total
    }

    public void PosDone()
    {
        if (i >= eM.RowConnectors.Count - 1)
        {
            //doeal damage to the players health
            //playerhealth.takedamage(damage);  <--- example code
            inactive = true;
            Debug.Log("die");
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


}
