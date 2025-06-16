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
    public Vector3 goBack = new Vector3(-13.13f, 0, 1);
    [SerializeField] private AudioClip[] clips;
    AudioManager audioM;


    private void Start()
    {
        chipForCash.onClick.AddListener(Exchange);
        addChip.onClick.AddListener(AddButton);
        takeAwayChip.onClick.AddListener(MinusButton);

        moneyChipsAreWorth = 0;
        chipsToBeTraded = 0;
        audioM = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
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
        int i = Random.Range(0, 3);
        audioM.PlaySFX(clips[i]);
        moneyMakingFromChips.text = "£0";
        chipsUsed.text = "chips used: 0";
        moneyChipsAreWorth = 0;
        chipsToBeTraded = 0;
        cashierGoTo.position = goBack;
    }
}
