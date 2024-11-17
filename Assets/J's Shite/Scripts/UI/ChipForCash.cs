using UnityEngine;
using UnityEngine.UI;

public class ChipForCash : MonoBehaviour
{
    [SerializeField] Button chipForCash;
    public CardIconBehaviour cardBehav;
    public MoneyManager moneyM;
    public HealthManager healthM;
    public GameObject chipIn;


    private void Start()
    {
        chipForCash.onClick.AddListener(Exchange);
    }

    void Exchange()
    {
        if (cardBehav.chipInSlot == true)
        {
            moneyM.playerMoney = moneyM.playerMoney + 25;
            healthM.playerChips = healthM.playerChips - 1;
            cardBehav.chipInSlot = false;
            chipIn.transform.position = new Vector3(12, 0, 0);
        }
    }
}
