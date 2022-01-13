using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class OptionsManager : MonoBehaviour
{
    [SerializeField] Slider musicSlider, effectsSlider; //Sliders for the music and effects volumes
    [SerializeField] AudioMixer audioMixer; //AudioMixer

    /// <summary>
    /// OnEnable method where we initialize the sliders and the attenuation levels
    /// If we didn't have one saved we set them at maximum volume
    /// </summary>

    private void OnEnable()
    {
        if(PlayerPrefs.GetString("MusicVolume") == "")
        {
            musicSlider.value = 0;
            PlayerPrefs.SetString("MusicVolume", musicSlider.value.ToString());
        }
        else
        {
            musicSlider.value = float.Parse(PlayerPrefs.GetString("MusicVolume"));
        }
        
        if(PlayerPrefs.GetString("EffectsVolume") == "")
        {
            effectsSlider.value = 0;
            PlayerPrefs.SetString("EffectsVolume", effectsSlider.value.ToString());
        }
        else
        {
            effectsSlider.value = float.Parse(PlayerPrefs.GetString("EffectsVolume"));
        }

        PlayerPrefs.SetString("MusicVolume", musicSlider.value.ToString());
        PlayerPrefs.SetString("EffectsVolume", effectsSlider.value.ToString());
    }

    /// <summary>
    /// Method to update the music's attenuation
    /// </summary>
    public void UpdateMusicVolume()
    {
        PlayerPrefs.SetString("MusicVolume", musicSlider.value.ToString());
        audioMixer.SetFloat("musicAttenuation", musicSlider.value);
    }

    /// <summary>
    /// Method to update the sound effects' attenuation
    /// </summary>
    public void UpdateEffectsVolume()
    {
        PlayerPrefs.SetString("EffectsVolume", effectsSlider.value.ToString());
        audioMixer.SetFloat("soundEffectsAttenuation", effectsSlider.value);
    }
}
