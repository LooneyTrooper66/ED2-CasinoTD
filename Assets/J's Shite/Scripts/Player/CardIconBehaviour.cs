using UnityEngine;

public class CardIconBehaviour : MonoBehaviour
{
    private bool isDragActive = false;
    private Vector3 screenPos;
    private Vector3 worldPos;
    private Vector3 mousePos;
    private Draggable lastDragged;
    private Camera mainCam;
    private float duration = 15f;

    public LayerMask overlapThing;
    public GameObject cardPrefab;
    public GameObject roulettePrefab;
    public GameObject horsePrefab;


    private void Awake()
    {
        mainCam = Camera.main;

        /*CardIconBehaviour[] controllers = FindObjectsOfType<CardIconBehaviour>();
        if (controllers.Length > 1)
        {
            Destroy(gameObject);
        }*/
    }

    private void Update()
    {
        if (isDragActive)
        {
            if (Input.GetMouseButtonUp(0) || (Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Ended))
            {
                Drop();
                return;
            }
        }

        if (Input.GetMouseButton(0))
        {
            mousePos = Input.mousePosition;
            screenPos = new Vector3(mousePos.x, mousePos.y, -1);
        }
        else if (Input.touchCount > 0)
        {
            screenPos = Input.GetTouch(0).position;
        }
        else
        {
            return;
        }

        worldPos = mainCam.ScreenToWorldPoint(screenPos);
        if (isDragActive)
        {
            Drag();
        }
        else
        {
            RaycastHit2D hit = Physics2D.Raycast(worldPos, Vector2.zero);
            if (hit.collider != null)
            {
                Draggable draggable = hit.transform.gameObject.GetComponent<Draggable>();
                if (draggable != null)
                {
                    lastDragged = draggable;
                    InitDrag();
                }
            }
        }
    }

    void InitDrag()
    {
        isDragActive = true;
    }

    void Drag()
    {
        lastDragged.transform.position = new Vector3(worldPos.x, worldPos.y, -3);
    }

    void PlaceTower()
    {
        isDragActive = false;
        if (lastDragged.tag == "card")
        {
            Instantiate(cardPrefab, lastDragged.gameObject.transform.position, transform.rotation);
            lastDragged.transform.position = new Vector3(8.25f, 4, -3);
        }
        else if (lastDragged.tag == "roulette")
        {
            Instantiate(roulettePrefab, lastDragged.gameObject.transform.position, transform.rotation);
            lastDragged.transform.position = new Vector3(8.25f, 3, -3);
        }
        else if (lastDragged.tag == "horse")
        {
            Instantiate(horsePrefab, lastDragged.gameObject.transform.position, transform.rotation);
            lastDragged.transform.position = new Vector3(8.25f, 2, -3);
        }
        else
        {
            return;
        }
    }

    void Drop()
    {
        isDragActive = false;
        Collider2D col = Physics2D.OverlapPoint(worldPos, overlapThing);
        if (col.gameObject.tag == "DropValid")
        {
            Debug.Log("ye");
            PlaceTower();
        }
        else
        {
            Debug.Log("na");
            MovePlacerBack();
        }
    }

    void MovePlacerBack()
    {
        float elapsedTime = 0;
        Vector3 spawnPoint;

        if (lastDragged.tag == "card")
        {
            spawnPoint = new Vector3(8.25f, 4, -3);
        }
        else if (lastDragged.tag == "roulette")
        {
            spawnPoint = new Vector3(8.25f, 3, -3);
        }
        else
        {
            spawnPoint = new Vector3(8.25f, 2, -3);
        }

        while (lastDragged.transform.position != spawnPoint)
        {
            elapsedTime += Time.deltaTime;
            float percentComp = elapsedTime / duration;
            lastDragged.transform.position = Vector3.Lerp(lastDragged.transform.position, spawnPoint, percentComp);
        }
    }
}
