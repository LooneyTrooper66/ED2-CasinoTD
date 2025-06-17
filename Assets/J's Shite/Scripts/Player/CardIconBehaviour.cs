using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CardIconBehaviour : MonoBehaviour
{
    [HideInInspector] public bool isDragActive = false;
    [HideInInspector] public bool cardInPlace = true;
    [HideInInspector] public bool rouletteInPlace = true;
    [HideInInspector] public bool horseInPlace = true;
    [HideInInspector] public bool chipInPlace = true;
    [HideInInspector] public bool chipInSlot = false;
    private Vector3 screenPos;
    private Vector3 worldPos;
    private Vector3 mousePos;
    private Draggable lastDragged;
    private Camera mainCam;
    [HideInInspector] public Vector3 startPos;

    public LayerMask overlapThing;
    public GameObject cardPrefab;
    public Vector3 cardPosition = new Vector3(-14.38f, 1.7f, -3);
    public GameObject roulettePrefab;
    public Vector3 roulettePosition = new Vector3(-11.88f, 2.2f, -3);
    public GameObject horsePrefab;
    public Vector3 horsePosition = new Vector3(-14.23f, -2f, -3);
    public MoneyManager money;
    public string hitTag;
    public Transform shopLerp;
    public AudioClip cannotPlaceSound;
    public AudioClip placeSound;
    AudioManager audioM;


    private void Awake()
    {
        mainCam = Camera.main;
        audioM = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
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
                    hitTag = hit.transform.gameObject.tag;
                    lastDragged = draggable;
                    InitDrag();
                }
            }
        }
    }

    void InitDrag()
    {
        isDragActive = true;
        if (shopLerp != null)
        {
            shopLerp.position = new Vector3(-13.13f, 0, 1);
        }
    }

    void Drag()
    {
        lastDragged.transform.position = new Vector3(worldPos.x, worldPos.y, -3);
    }

    void PlaceTower(Transform placeSurface)
    {
        Vector3 placeSpot = new Vector3(lastDragged.gameObject.transform.position.x, lastDragged.gameObject.transform.position.y, -2.5f);
        isDragActive = false;
        switch (lastDragged.gameObject.tag)
        {
            case "card":
                Instantiate(cardPrefab, placeSpot, transform.rotation, placeSurface);
                lastDragged.transform.position = cardPosition;
                audioM.PlaySFX(placeSound);
                money.playerMoney = money.playerMoney - 25;
                return;
            case "roulette":
                Instantiate(roulettePrefab, placeSpot, transform.rotation, placeSurface);
                lastDragged.transform.position = roulettePosition;
                audioM.PlaySFX(placeSound);
                money.playerMoney = money.playerMoney - 150;
                return;
            case "horse":
                Instantiate(horsePrefab, placeSpot, transform.rotation, placeSurface);
                lastDragged.transform.position = horsePosition;
                audioM.PlaySFX(placeSound);
                money.playerMoney = money.playerMoney - 80;
                return;
        }
    }

    void Drop()
    {
        isDragActive = false;
        Collider2D col = Physics2D.OverlapPoint(worldPos, overlapThing);
        if (col.gameObject.tag == "DropValid")
        {
            Transform placeSurface = col.gameObject.transform;

            PlaceTower(placeSurface);
        }
        else
        {
            audioM.PlaySFX(cannotPlaceSound);
            MovePlacerBack();
        }
    }

    void MovePlacerBack()
    {
        startPos = lastDragged.transform.position;
        switch (lastDragged.gameObject.tag)
        {
            case "card":
                cardInPlace = false;
                return;
            case "roulette":
                rouletteInPlace = false;
                return;
            case "horse":
                horseInPlace = false;
                return;
        }
    }
}
