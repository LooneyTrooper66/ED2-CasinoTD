using UnityEngine;

public class CardBulletBehaviour : MonoBehaviour
{
    private Vector2 startPos;


    private void Start()
    {
        startPos = new Vector2(transform.position.x, transform.position.y);
    }

    private void Update()
    {
        if (Vector2.Distance(transform.position, startPos) >= 5)
        {
            Destroy(gameObject);
        }
        else
        {
            transform.Translate(Vector2.up);
        }
    }
}
