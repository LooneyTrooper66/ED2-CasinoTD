using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("--- Audio Source ---")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource sfxSource;

    [Header("--- Audio Clip ---")]
    public AudioClip menuMusic;
    //public AudioClip leverPull; // dont include coins sound here as needs to be randomly chosen from array
    //public AudioClip boardSpin;
    //public AudioClip uiButtonClick;


    private void Start()
    {
        musicSource.clip = menuMusic;
        musicSource.Play();
    }

    public void PlaySFX(AudioClip clip)
    {
        sfxSource.PlayOneShot(clip);
    }
}
