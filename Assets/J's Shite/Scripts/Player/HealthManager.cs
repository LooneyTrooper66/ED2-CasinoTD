using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HealthManager : MonoBehaviour
{
    [SerializeField] Text chipsText;
    public int playerChips;


    private void FixedUpdate()
    {
        string chipsStr = playerChips.ToString();
        chipsText.text = $"{chipsStr}";

        if (playerChips >= 0)
        {
            SceneManager.LoadScene("DeathScreen");
        }
    }

    public void TakeDamage(int damage)
    {
        playerChips -= damage;
    }
}
