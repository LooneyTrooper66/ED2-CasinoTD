using UnityEngine;
using UnityEngine.UI;

public class SpawnRoulette : MonoBehaviour
{
    [SerializeField] Button spawnButton;
    public GameObject roulettePrefab;
    private Vector3 spawnPoint;


    private void Start()
    {
        spawnButton.onClick.AddListener(RouletteSpawned);
        spawnPoint = new Vector3(spawnButton.transform.position.x, spawnButton.transform.position.y, -3);
    }

    public void RouletteSpawned()
    {
        Instantiate(roulettePrefab, spawnPoint, transform.rotation);
    }
}
