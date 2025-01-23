using UnityEngine;

public class SpriteOutlineRed : MonoBehaviour
{
    private SpriteRenderer sR;
    private Vector3 screenPos;
    private Vector3 worldPos;
    private Vector3 mousePos;
    private Camera mainCam;
    public LayerMask ignorePlacer;
    public CardIconBehaviour placerScript;


    private void Start()
    {
        sR = GetComponent<SpriteRenderer>();
        mainCam = Camera.main;
    }

    private void Update()
    {
        if (Input.GetMouseButton(0) && placerScript.isDragActive == true)
        {
            mousePos = Input.mousePosition;
            screenPos = new Vector3(mousePos.x, mousePos.y, -1);

            worldPos = mainCam.ScreenToWorldPoint(screenPos);

            RaycastHit2D hit = Physics2D.Raycast(worldPos, Vector2.zero, Mathf.Infinity, ignorePlacer);
            if (hit.collider.tag == "DropValid")
            {
                sR.color = Color.white;
            }
            else
            {
                sR.color = Color.red;
            }
        }
        else if (Input.touchCount > 0 && placerScript.isDragActive == true)
        {
            screenPos = Input.GetTouch(0).position;

            worldPos = mainCam.ScreenToWorldPoint(screenPos);

            RaycastHit2D hit = Physics2D.Raycast(worldPos, Vector2.zero, Mathf.Infinity, ignorePlacer);
            if (hit.collider.tag == "DropValid")
            {
                sR.color = Color.white;
            }
            else
            {
                sR.color = Color.red;
            }
        }
    }
}
