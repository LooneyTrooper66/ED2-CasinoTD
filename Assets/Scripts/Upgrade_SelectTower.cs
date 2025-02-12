using UnityEngine;

public class Upgrade_SelectTower : MonoBehaviour
{
    [SerializeField] LayerMask LayerMask;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //set postion 
            CheckUpgrade(Camera.main.ScreenToWorldPoint(Input.mousePosition)); //
        }
        else if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            //set postion
            CheckUpgrade(Input.GetTouch(0).position);
        }
    }

    void CheckUpgrade(Vector3 pos)
    {
        //shoot raycast at postion
        RaycastHit2D hit;
        hit = Physics2D.Raycast(pos ,Vector3.forward,10,LayerMask);
        if (hit)
        {
            Debug.Log(hit);
            // get the information from that tower and call the right functions 
            if (hit.collider.gameObject.GetComponent<Tower_Upgrade>())
            {
                hit.collider.gameObject.GetComponent<Tower_Upgrade>().Upgrade_check();
            }
            else if (hit.collider.gameObject.transform.parent && hit.collider.gameObject.transform.parent.GetChild(0) && hit.collider.gameObject.transform.parent.GetChild(0).GetComponent<Tower_Upgrade>()) //use for the card and roulet as the compoent is on the first child not the gameobejct 
            {
                hit.collider.gameObject.transform.parent.GetChild(0).GetComponent<Tower_Upgrade>().Upgrade_check();
            }
        }
    }
}
