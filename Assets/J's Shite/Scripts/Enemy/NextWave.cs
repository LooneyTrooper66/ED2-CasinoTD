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
        // this wont be a button in the real thing, this is just here to simulate completing a wave to reset the amount of chips you can spend

        chipTrade.tradableChipsThisRound = 5;
    }
}
