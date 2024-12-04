using System;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class ProjectileBehaviour : MonoBehaviour
{
   private Vector3 dir;
    [SerializeField]private float damage;
    public float speed;
    [SerializeField] private float deathTimer;
    private bool deathStart;

    private void Start()
    {
       // startPos = transform.position;
    }

    private void FixedUpdate()
    {
        transform.position += dir * speed / 50;
        transform.Rotate(Vector3.forward,1);

        if (deathStart) //auto kill the projectile if it dosnt hit its target
        {
            deathTimer -= 1 / 50;
            if (deathTimer <= 0)
            {
                Destroy(gameObject);
            }
        }
    }

     public void Spawn(Vector2 dirt)         
     {
         //set the direction and shite 
         //pendist
         dir = dirt;
        deathStart = true;
        // transform.LookAt(dirt);
        transform.rotation = Quaternion.FromToRotation(Vector3.up, dirt);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("0");
        if (collision.gameObject.CompareTag("enemy"))
        {
            Debug.Log(1);
            collision.gameObject.GetComponent<enemy_Move>().Hit(damage);
            Destroy(gameObject);
        }

    }
}
