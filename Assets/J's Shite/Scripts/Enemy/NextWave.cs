using UnityEngine;
using UnityEngine.UI;

public class NextWave : MonoBehaviour
{
    [SerializeField] Button nextWave;
    public ChipForCash chipTrade;


    private void Start()
    {
        nextWave.onClick.AddListener(ToNextWave);
    }

    void ToNextWave()
    {
        chipTrade.tradableChipsThisRound = 5;
    }
}
