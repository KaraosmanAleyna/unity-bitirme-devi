using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class music : MonoBehaviour
{
    public AudioSource musicSource;
    public Toggle musicToggle;
    public Slider volumeSlider;

    void Start()
    {
        // Toggle'ýn durumunu kaydedebilmek için PlayerPrefs kullanýyoruz
        if (PlayerPrefs.HasKey("MusicOn"))
        {
            bool isMusicOn = PlayerPrefs.GetInt("MusicOn") == 1 ? true : false;
            musicToggle.isOn = isMusicOn;
            if (isMusicOn)
            {
                musicSource.Play();
            }
        }
        else
        {
            // Baþlangýçta müziði açýk varsayalým
            musicToggle.isOn = true;
            musicSource.Play();
        }

        // Ses seviyesini kaydetmek için PlayerPrefs kullanýyoruz
        if (PlayerPrefs.HasKey("MusicVolume"))
        {
            float savedVolume = PlayerPrefs.GetFloat("MusicVolume");
            volumeSlider.value = savedVolume;
            musicSource.volume = savedVolume;
        }
        else
        {
            // Baþlangýçta ses seviyesini maksimuma ayarlayalým
            volumeSlider.value = 1f;
            musicSource.volume = 1f;
        }
    }

    public void ToggleMusic()
    {
        if (musicToggle.isOn)
        {
            musicSource.Play();
            PlayerPrefs.SetInt("MusicOn", 1); // Müzik açýk olduðunu kaydet
        }
        else
        {
            musicSource.Pause();
            PlayerPrefs.SetInt("MusicOn", 0); // Müzik kapalý olduðunu kaydet
        }
    }

    public void ChangeVolume()
    {
        float volume = volumeSlider.value;
        musicSource.volume = volume;
        PlayerPrefs.SetFloat("MusicVolume", volume); // Ses seviyesini kaydet
    }
}
