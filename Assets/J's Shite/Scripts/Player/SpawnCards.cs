using UnityEngine;
using UnityEngine.UI;

public class SpawnCards : MonoBehaviour
{
    [SerializeField] Button spawnButton;
    public GameObject cardsIcon;
    private Vector3 spawnPoint;


    private void Start()
    {
        spawnButton.onClick.AddListener(CardsSpawned);
        spawnPoint = new Vector3(spawnButton.transform.position.x, spawnButton.transform.position.y, -3);
    }

    public void CardsSpawned()
    {
        cardsIcon.transform.position = spawnPoint;

        //Instantiate(cardsPrefab, spawnPoint, transform.rotation);
    }
}
