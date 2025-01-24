using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    [Header("--- Audio Source ---")]
    [SerializeField] private AudioMixer mixer;

    [Header("--- Audio Source ---")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource sfxSource;

    [Header("--- Audio Clip ---")]
    public AudioClip menuMusic;
    //public AudioClip leverPull; // dont include coins sound here as needs to be randomly chosen from array
    //public AudioClip boardSpin;
    //public AudioClip uiButtonClick;


    // to set all volumes to last used settings on game load, also starts playing menu music
    private void Start()
    {
        if (PlayerPrefs.HasKey("masterVol"))
        {
            float masterVolume = PlayerPrefs.GetFloat("masterVol");
            mixer.SetFloat("master", Mathf.Log10(masterVolume) * 20);
        }
        else
        {
            mixer.SetFloat("master", 20);
        }

        if (PlayerPrefs.HasKey("musicVol"))
        {
            float musicVolume = PlayerPrefs.GetFloat("musicVol");
            mixer.SetFloat("music", Mathf.Log10(musicVolume) * 20);
        }
        else
        {
            mixer.SetFloat("music", -6);
        }

        if (PlayerPrefs.HasKey("sfxVol"))
        {
            float sfxVolume = PlayerPrefs.GetFloat("sfxVol");
            mixer.SetFloat("sfx", Mathf.Log10(sfxVolume) * 20);
        }
        else
        {
            mixer.SetFloat("sfx", -6);
        }

        musicSource.clip = menuMusic;
        musicSource.Play();
    }

    public void PlaySFX(AudioClip clip)
    {
        sfxSource.PlayOneShot(clip);
    }
}
