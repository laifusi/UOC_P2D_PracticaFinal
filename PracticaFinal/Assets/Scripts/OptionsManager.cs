using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class OptionsManager : MonoBehaviour
{
    [SerializeField] Slider musicSlider, effectsSlider; //Sliders for the music and effects volumes
    [SerializeField] AudioMixer audioMixer; //AudioMixer

    /// <summary>
    /// Start method where we initialize the sliders and the attenuation levels
    /// If we didn't have one saved we set them at maximum volume
    /// </summary>
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

    /// <summary>
    /// Method to update the music's attenuation
    /// </summary>
    public void UpdateMusicVolume()
    {
        PlayerPrefs.SetFloat("MusicVolume", musicSlider.value);
        audioMixer.SetFloat("musicAttenuation", musicSlider.value);
    }

    /// <summary>
    /// Method to update the sound effects' attenuation
    /// </summary>
    public void UpdateEffectsVolume()
    {
        PlayerPrefs.SetFloat("EffectsVolume", effectsSlider.value);
        audioMixer.SetFloat("soundEffectsAttenuation", effectsSlider.value);
    }
}
