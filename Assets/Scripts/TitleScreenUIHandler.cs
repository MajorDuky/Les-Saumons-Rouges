#if UNITY_EDITOR
    using UnityEditor;
#endif
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitleScreenUIHandler : MonoBehaviour
{
    [SerializeField] private GameObject SettingsSection;
    [SerializeField] private Slider SliderBGVolume;
    [SerializeField] private Slider SliderFXVolume;
    [SerializeField] private GameManager gameManager;
    [SerializeField] private AudioClip MainMenuSoundTrack;
    void Start()
    {
        gameManager.ChangeBGMusic(MainMenuSoundTrack);
        OnValueChangedBGVolume();
        OnValueChangedFXVolume();
    }
    public void OnClickSettingsButton()
    {
        if (!SettingsSection.activeInHierarchy)
        {
            SettingsSection.SetActive(true);
        }
    }

    public void OnValueChangedBGVolume()
    {
        gameManager.BGVolume = SliderBGVolume.value;
    }

    public void OnValueChangedFXVolume()
    {
        gameManager.FXVolume = SliderFXVolume.value;
    }

    public void Exit()
    {
    #if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
    #else
        Application.Quit();
    #endif
    }
}
