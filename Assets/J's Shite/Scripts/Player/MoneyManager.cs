using UnityEngine;
using UnityEngine.UI;

public class MoneyManager : MonoBehaviour
{
    [SerializeField] Text moneyText;
    public int playerMoney;


    private void Start()
    {
        moneyText = GetComponent<Text>();
        playerMoney = 5;
    }

    private void Update()
    {
        string moneyStr = playerMoney.ToString();
        moneyText.text = $"money - £{moneyStr}";
    }
}
