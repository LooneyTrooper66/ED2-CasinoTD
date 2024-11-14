using UnityEngine;

public class Draggable : MonoBehaviour
{
    /*public Vector3 spawnPoint;
    private float movementTime = 15f;
    private System.Nullable<Vector3> movementDestination;
    public CardIconBehaviour cardController;


    private void FixedUpdate()
    {
        if (movementDestination.HasValue)
        {
            // if has been dropped in invalid area, lerp to starting pos

            if (transform.position == movementDestination)
            {
                movementDestination = null;
            }
            else
            {
                transform.position = Vector3.Lerp(transform.position, movementDestination.Value, movementTime * Time.deltaTime);
            }
        }
    }

    private void OnMouseUp()
    {
        RaycastHit2D hit = Physics2D.Raycast(Input.mousePosition, Vector2.zero);
        if (hit.collider.CompareTag("DropInvalid"))
        {
            Debug.Log("Invalid");
            movementDestination = spawnPoint;
        }
    }*/

    /*private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "DropInvalid")
        {
            Debug.Log("Invalid");
            movementDestination = spawnPoint;
        }
    }*/
}
