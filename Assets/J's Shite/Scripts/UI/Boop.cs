using UnityEngine;
using UnityEngine.UI;

public class Boop : MonoBehaviour
{
    [SerializeField] private AudioClip clip;
    AudioManager audioM;
    Button button;


    private void Awake()
    {
        audioM = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
        button = GetComponent<Button>();
        button.onClick.AddListener(PlayBoop);
    }

    void PlayBoop()
    {
        audioM.PlaySFX(clip);
    }
}
