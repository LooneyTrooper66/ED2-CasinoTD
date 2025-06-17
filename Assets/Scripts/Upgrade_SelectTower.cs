using UnityEngine;
using UnityEngine.UI;

public class Upgrade_SelectTower : MonoBehaviour
{
    [SerializeField] LayerMask LayerMask;
    public GameObject upgradeInfoTab;
    Button upgradeButton;
    Text upgradePrice;
    Tower_Upgrade currentTower = null;
    Vector3 lastTap;


    void Start()
    {
        upgradeButton = upgradeInfoTab.GetComponentInChildren<Button>();
        upgradePrice = upgradeInfoTab.GetComponentInChildren<Text>();
        upgradeInfoTab.SetActive(false);
        upgradeButton.onClick.AddListener(ButtonClicked);
        lastTap = new Vector3(30, 1, 30);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (upgradeInfoTab.activeSelf == true && Vector3.Distance(lastTap, Camera.main.ScreenToWorldPoint(Input.mousePosition)) >= 1.5f)
            {
                currentTower = null;
                upgradeInfoTab.SetActive(false);
            }
            else CheckUpgrade(Camera.main.ScreenToWorldPoint(Input.mousePosition));
        }
        else if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            if (upgradeInfoTab.activeSelf == true && Vector3.Distance(lastTap, Input.GetTouch(0).position) >= 1.5f)
            {
                currentTower = null;
                upgradeInfoTab.SetActive(false);
            }
            else CheckUpgrade(Input.GetTouch(0).position);
        }
    }

    void CheckUpgrade(Vector3 pos)
    {
        //shoot raycast at postion
        RaycastHit2D hit;
        hit = Physics2D.Raycast(pos ,Vector3.forward,10,LayerMask);
        if (hit)
        {
            // get the information from that tower and call the right functions 
            if (hit.collider.gameObject.transform.parent.GetComponent<Tower_Upgrade>())
            {
                hit.collider.gameObject.GetComponent<Tower_Upgrade>().Upgrade_check(pos);
            }
            else if (hit.collider.gameObject.transform.parent && hit.collider.gameObject.transform.parent.GetChild(0) && hit.collider.gameObject.transform.parent.GetChild(0).GetComponent<Tower_Upgrade>()) //use for the card and roulet as the compoent is on the first child not the gameobejct 
            {
                hit.collider.gameObject.transform.parent.GetChild(0).GetComponent<Tower_Upgrade>().Upgrade_check(pos);
            }
            lastTap = pos;
        }
    }

    public void MoveUpgradeTab(Vector3 clickPos, Tower_Upgrade currentUpgrade, int cost)
    {
        upgradeInfoTab.transform.position = new Vector3(clickPos.x, clickPos.y, -8);
        string price = cost.ToString();
        upgradePrice.text = $"£{price}";
        upgradeInfoTab.SetActive(true);

        currentTower = currentUpgrade;
    }

    void ButtonClicked()
    {
        currentTower.UpgradeTower();
        currentTower = null;
        upgradeInfoTab.SetActive(false);
    }
}
