using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeManager : MonoBehaviour
{
    [SerializeField] private AudioMixer audioMixer;
    [SerializeField] private Slider masterSlider;
    [SerializeField] private Slider musicSlider;
    [SerializeField] private Slider sfxSlider;


    private void Start()
    {
        if (PlayerPrefs.HasKey("masterVol"))
        {
            masterSlider.value = PlayerPrefs.GetFloat("masterVol");
        }
        else
        {
            masterSlider.value = 1;
        }

        if (PlayerPrefs.HasKey("musicVol"))
        {
            musicSlider.value = PlayerPrefs.GetFloat("musicVol");
        }
        else
        {
            musicSlider.value = 0.5f;
        }

        if (PlayerPrefs.HasKey("sfxVol"))
        {
            sfxSlider.value = PlayerPrefs.GetFloat("sfxVol");
        }
        else
        {
            sfxSlider.value = 0.5f;
        }
    }

    public void SetMasterVol()
    {
        float masterVol = masterSlider.value;
        PlayerPrefs.SetFloat("masterVol", masterVol);
        audioMixer.SetFloat("master", Mathf.Log10(masterVol) * 20);
    }

    public void SetMusicVol()
    {
        float musicVol = musicSlider.value;
        PlayerPrefs.SetFloat("musicVol", musicVol);
        audioMixer.SetFloat("music", Mathf.Log10(musicVol) * 20);
    }

    public void SetSFXVol()
    {
        float sfxVol = sfxSlider.value;
        PlayerPrefs.SetFloat("sfxVol", sfxVol);
        audioMixer.SetFloat("sfx", Mathf.Log10(sfxVol) * 20);
    }
}
