using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    [SerializeField] Text chipsText;
    public int playerChips;


    private void Start()
    {
        chipsText = GetComponent<Text>();
        playerChips = 100;
    }

    private void Update()
    {
        string chipsStr = playerChips.ToString();
        chipsText.text = $"chips - {chipsStr}";
    }
}
