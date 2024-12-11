using System;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class ProjectileBehaviour : MonoBehaviour
{
    private Vector3 dir;
    [SerializeField] private float damage;
    public float speed;
    [SerializeField] private float deathTimer;
    //private bool deathStart;
    [SerializeField] private int peirce;
    private Vector2 startPos;
    
    private void Start()
    {
        startPos = new Vector2(transform.position.x, transform.position.y);
    }

    private void FixedUpdate()
    {
        transform.position += dir * speed / 50;
        transform.Rotate(Vector3.forward,1);

        if (Vector2.Distance(transform.position, startPos) >= 4)
        {
            Destroy(gameObject);
        }
    }

     public void Spawn(Vector2 dirt)         
     {
         //set the direction and shite 
         //pendist
         dir = dirt;
        //deathStart = true;
        // transform.LookAt(dirt);
        transform.rotation = Quaternion.FromToRotation(Vector3.up, dirt);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Debug.Log("0");
        if (collision.gameObject.CompareTag("enemy"))
        {
            //Debug.Log(1);
            collision.gameObject.GetComponent<enemy_Move>().Hit(damage);
            peirce--;
            Destroy((peirce <= 0)? gameObject : null); 
            Destroy(gameObject);
        }

    }
}
