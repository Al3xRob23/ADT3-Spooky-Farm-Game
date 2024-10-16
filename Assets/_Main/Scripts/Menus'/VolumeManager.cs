using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeManager : MonoBehaviour
{
    [SerializeField] Slider musicSlider;
    [SerializeField] Slider sfxSlider;
    [SerializeField] Slider masterSlider;

    // Start is called before the first frame update
    void Start()
    {
        if (!PlayerPrefs.HasKey("musicVolume"))
        {
            Initialize();
            Load();
        }

        else
        {
            Load();
        }
    }

    void Initialize()
    {
        PlayerPrefs.SetFloat("musicVolume", 1);
        PlayerPrefs.SetFloat("sfxVolume", 1);
        PlayerPrefs.SetFloat("masterVolume", 1);
    }

    public void Load()
    {
        musicSlider.value = PlayerPrefs.GetFloat("musicVolume");
        sfxSlider.value = PlayerPrefs.GetFloat("sfxVolume");
        masterSlider.value = PlayerPrefs.GetFloat("masterVolume");
    }

    public void Save()
    {
        PlayerPrefs.SetFloat("musicVolume", musicSlider.value);
        PlayerPrefs.SetFloat("sfxVolume", sfxSlider.value);
        PlayerPrefs.SetFloat("masterVolume", masterSlider.value);
    }

    public void OnDestroy()
    {
        Save();
    }


}
