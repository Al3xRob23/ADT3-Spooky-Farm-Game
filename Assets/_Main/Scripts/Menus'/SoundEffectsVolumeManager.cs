using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundEffectsVolumeManager : MonoBehaviour
{
    [SerializeField] Slider effectsVolume;

    // Start is called before the first frame update
    void Start()
    {
        if (!PlayerPrefs.HasKey("effectsVolume"))
        {
            PlayerPrefs.SetFloat("effectsVolume", 1);
            Load();
        }

        else
        {
            Load();
        }
    }
    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void ChangeVolume()
    {
        AudioListener.volume = effectsVolume.value;
        Save();
    }
    public void Load()
    {
        effectsVolume.value = PlayerPrefs.GetFloat("effectsVolume");
    }
    public void Save()
    {
        PlayerPrefs.SetFloat("effectsVolume", effectsVolume.value);
    }


}
