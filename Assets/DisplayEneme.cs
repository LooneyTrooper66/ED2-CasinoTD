using UnityEngine;
using UnityEngine.UI;

public class DisplayEneme : MonoBehaviour
{
    public enemy_Manager em;
    public GameObject gm;
    public Text text;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        text.text = ($"Enemy Remaining: {em.activeWave.Count + gm.transform.childCount}" );
    }
}
