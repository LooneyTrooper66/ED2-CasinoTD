using UnityEngine;
using UnityEngine.UI;

public class ChipForCash : MonoBehaviour
{
    [SerializeField] Button chipForCash;
    [SerializeField] Button addChip;
    [SerializeField] Button takeAwayChip;
    [SerializeField] Text chipsUsed;
    [SerializeField] Text moneyMakingFromChips;
    private int chipsToBeTraded;
    private int moneyChipsAreWorth;
    public int tradableChipsThisRound = 3;
    public MoneyManager moneyM;
    public HealthManager healthM;
    public Transform cashierGoTo;


    private void Start()
    {
        chipForCash.onClick.AddListener(Exchange);
        addChip.onClick.AddListener(AddButton);
        takeAwayChip.onClick.AddListener(MinusButton);

        moneyChipsAreWorth = 0;
        chipsToBeTraded = 0;
    }

    void AddButton()
    {
        if (tradableChipsThisRound >= 1)
        {
            moneyChipsAreWorth = moneyChipsAreWorth + 25;
            chipsToBeTraded = chipsToBeTraded + 1;

            string moneyStr = moneyChipsAreWorth.ToString();
            moneyMakingFromChips.text = $"£{moneyStr}";
            string chipStr = chipsToBeTraded.ToString();
            chipsUsed.text = $"chips used: {chipStr}";

            tradableChipsThisRound--;
        }
    }

    void MinusButton()
    {
        if (chipsToBeTraded >= 1)
        {
            moneyChipsAreWorth = moneyChipsAreWorth - 25;
            chipsToBeTraded = chipsToBeTraded - 1;

            string moneyStr = moneyChipsAreWorth.ToString();
            moneyMakingFromChips.text = $"£{moneyStr}";
            string chipStr = chipsToBeTraded.ToString();
            chipsUsed.text = $"chips used: {chipStr}";

            tradableChipsThisRound++;
        }
    }

    void Exchange()
    {
        moneyM.playerMoney = moneyM.playerMoney + moneyChipsAreWorth;
        healthM.playerChips = healthM.playerChips - chipsToBeTraded;
        moneyMakingFromChips.text = "£0";
        chipsUsed.text = "chips used: 0";
        moneyChipsAreWorth = 0;
        chipsToBeTraded = 0;
        cashierGoTo.position = new Vector3(-13.13f, 0, 1);
    }
}
