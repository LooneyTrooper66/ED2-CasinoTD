using UnityEngine;
using UnityEngine.UI;

public class SpawnHorse : MonoBehaviour
{
    [SerializeField] Button spawnButton;
    public GameObject horsePrefab;
    private Vector3 spawnPoint;


    private void Start()
    {
        spawnButton.onClick.AddListener(HorseSpawned);
        spawnPoint = new Vector3(spawnButton.transform.position.x, spawnButton.transform.position.y, -3);
    }

    public void HorseSpawned()
    {
        Instantiate(horsePrefab, spawnPoint, transform.rotation);
    }
}
