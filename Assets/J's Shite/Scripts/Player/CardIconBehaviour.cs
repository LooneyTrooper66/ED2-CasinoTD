using UnityEngine;

public class CardIconBehaviour : MonoBehaviour
{
    private bool isDragActive = false;
    public bool cardInPlace = true;
    public bool rouletteInPlace = true;
    public bool horseInPlace = true;
    private Vector3 screenPos;
    private Vector3 worldPos;
    private Vector3 mousePos;
    private Draggable lastDragged;
    private Camera mainCam;
    public Vector3 startPos;

    public LayerMask overlapThing;
    public GameObject cardPrefab;
    public GameObject roulettePrefab;
    public GameObject horsePrefab;
    public MoneyManager money;


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
        Vector3 placeSpot = new Vector3(lastDragged.gameObject.transform.position.x, lastDragged.gameObject.transform.position.y, -2.5f);
        isDragActive = false;
        if (lastDragged.tag == "card")
        {
            Instantiate(cardPrefab, placeSpot, transform.rotation);
            lastDragged.transform.position = new Vector3(8.25f, 3, -3);
            // money =- some money
        }
        else if (lastDragged.tag == "roulette")
        {
            Instantiate(roulettePrefab, placeSpot, transform.rotation);
            lastDragged.transform.position = new Vector3(8.25f, 2, -3);
            // money =- some money
        }
        else if (lastDragged.tag == "horse")
        {
            Instantiate(horsePrefab, placeSpot, transform.rotation);
            lastDragged.transform.position = new Vector3(8.25f, 1, -3);
            // money =- some money
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
            PlaceTower();
        }
        else
        {
            MovePlacerBack();
        }
    }

    void MovePlacerBack()
    {
        startPos = lastDragged.transform.position;
        if (lastDragged.tag == "card")
        {
            cardInPlace = false;
        }
        else if (lastDragged.tag == "roulette")
        {
            rouletteInPlace = false;
        }
        else if (lastDragged.tag == "horse")
        {
            horseInPlace = false;
        }
    }
}
