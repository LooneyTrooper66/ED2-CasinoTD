using UnityEngine;

public class CardBulletBehaviour : MonoBehaviour
{
    private Vector2 startPos;
    public float bulletSpeed;
    [SerializeField] private float damage;


    private void Start()
    {
        startPos = new Vector2(transform.position.x, transform.position.y);
    }

    private void Update()
    {
        if (Vector2.Distance(transform.position, startPos) >= 4)
        {
            Destroy(gameObject);
        }
        else
        {
            transform.Translate(Vector2.up * (bulletSpeed * Time.deltaTime));
        }
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
