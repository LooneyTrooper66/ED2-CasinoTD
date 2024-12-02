using UnityEngine;
using UnityEngine.UI;

public class MoneyManager : MonoBehaviour
{
    [SerializeField] Text moneyText;
    public int playerMoney;


    private void Update()
    {
        string moneyStr = playerMoney.ToString();
        moneyText.text = $"£{moneyStr}";
    }
}
