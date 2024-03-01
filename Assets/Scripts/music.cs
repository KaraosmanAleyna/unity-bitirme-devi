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
        // Toggle'�n durumunu kaydedebilmek i�in PlayerPrefs kullan�yoruz
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
            // Ba�lang��ta m�zi�i a��k varsayal�m
            musicToggle.isOn = true;
            musicSource.Play();
        }

        // Ses seviyesini kaydetmek i�in PlayerPrefs kullan�yoruz
        if (PlayerPrefs.HasKey("MusicVolume"))
        {
            float savedVolume = PlayerPrefs.GetFloat("MusicVolume");
            volumeSlider.value = savedVolume;
            musicSource.volume = savedVolume;
        }
        else
        {
            // Ba�lang��ta ses seviyesini maksimuma ayarlayal�m
            volumeSlider.value = 1f;
            musicSource.volume = 1f;
        }
    }

    public void ToggleMusic()
    {
        if (musicToggle.isOn)
        {
            musicSource.Play();
            PlayerPrefs.SetInt("MusicOn", 1); // M�zik a��k oldu�unu kaydet
        }
        else
        {
            musicSource.Pause();
            PlayerPrefs.SetInt("MusicOn", 0); // M�zik kapal� oldu�unu kaydet
        }
    }

    public void ChangeVolume()
    {
        float volume = volumeSlider.value;
        musicSource.volume = volume;
        PlayerPrefs.SetFloat("MusicVolume", volume); // Ses seviyesini kaydet
    }
}
