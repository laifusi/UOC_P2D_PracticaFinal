using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class OptionsManager : MonoBehaviour
{
    [SerializeField] Slider musicSlider, effectsSlider;
    [SerializeField] AudioMixer audioMixer;

    private void Start()
    {
        if(PlayerPrefs.GetString("MusicVolume") == "")
        {
            musicSlider.value = 0;
            PlayerPrefs.SetString("MusicVolume", musicSlider.value.ToString());
        }
        else
        {
            musicSlider.value = PlayerPrefs.GetFloat("MusicVolume");
        }
        
        if(PlayerPrefs.GetString("EffectsVolume") == "")
        {
            effectsSlider.value = 0;
            PlayerPrefs.SetString("EffectsVolume", effectsSlider.value.ToString());
        }
        else
        {
            effectsSlider.value = PlayerPrefs.GetFloat("EffectsVolume");
        }

        audioMixer.SetFloat("musicAttenuation", musicSlider.value);
        audioMixer.SetFloat("soundEffectsAttenuation", effectsSlider.value);
    }

    public void UpdateMusicVolume()
    {
        PlayerPrefs.SetFloat("MusicVolume", musicSlider.value);
        audioMixer.SetFloat("musicAttenuation", musicSlider.value);
    }

    public void UpdateEffectsVolume()
    {
        PlayerPrefs.SetFloat("EffectsVolume", effectsSlider.value);
        audioMixer.SetFloat("soundEffectsAttenuation", effectsSlider.value);
    }
}
