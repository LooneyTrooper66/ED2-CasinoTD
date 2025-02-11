using UnityEngine;
using System.Collections;

public class TwinkDeath : MonoBehaviour
{
    // kills the particle systems object after 3 seconds so they dont multiply like rabbits and overthrow the government \\
    [SerializeField] private AudioClip[] clips;
    AudioManager audioM;
    bool audioFound;

    private void Awake()
    {
        if (GameObject.FindGameObjectWithTag("Audio") != null)
        {
            audioM = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
            audioFound = true;
        }
    }

    private void Start()
    {
        if (audioFound)
        {
            int i = Random.Range(0, 3);
            audioM.PlaySFX(clips[i]);
        }
        StartCoroutine(Die());
    }

    IEnumerator Die()
    {
        yield return new WaitForSecondsRealtime(2.5f);
        Destroy(gameObject);
    }
}
