using UnityEngine;

public class CardBulletBehaviour : MonoBehaviour
{
    private Vector2 startPos;
    public float bulletSpeed;


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
}
