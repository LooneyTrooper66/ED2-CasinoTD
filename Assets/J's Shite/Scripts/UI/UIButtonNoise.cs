using UnityEngine;

public class UIButtonNoise : MonoBehaviour
{
    [SerializeField] private AudioClip clip;
    AudioManager audioM;

    private void Start()
    {
        audioM = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    public void OnClick()
    {
        if (audioM != null)
        audioM.PlaySFX(clip);
    }
}
