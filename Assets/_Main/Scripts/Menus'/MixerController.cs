using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class MixerController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private AudioMixer myAudioMixer;

    public void SetMasterVolume(float sliderValue)
    {
        myAudioMixer.SetFloat("Master Volume", Mathf.Log10(sliderValue) * 20);
    }
    public void SetMusicVolume(float sliderValue)
    {
        myAudioMixer.SetFloat("Music", Mathf.Log10(sliderValue) * 20);
    }
    public void SetSoundEffectsVolume(float sliderValue)
    {
        myAudioMixer.SetFloat("Sound Effects", Mathf.Log10(sliderValue) * 20);
    }

}
