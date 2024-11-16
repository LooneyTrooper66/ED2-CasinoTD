using UnityEngine;

public class TowerPurchaseAvailable : MonoBehaviour
{
    public Color available;
    public Color unavailable;
    public int price; // remember to change the values in other scripts if this is edited
    public int upgradePrice;
    public MoneyManager moneyM;
    private Collider2D thisCol;
    private SpriteRenderer sR;


    private void Start()
    {
        sR = GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        if (moneyM.playerMoney >= price)
        {
            sR.color = available;
            gameObject.GetComponent<Collider2D>().enabled = true;
        }
        else
        {
            sR.color = unavailable;
            gameObject.GetComponent<Collider2D>().enabled = false;
        }
    }


}
