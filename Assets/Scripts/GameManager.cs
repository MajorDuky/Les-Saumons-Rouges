using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{   
    public static GameManager Instance { get; private set; }
    [SerializeField] private AudioSource BG;
    [SerializeField] private AudioSource FX;

    private float _BGVolume;
    public float BGVolume 
    { 
        get { return _BGVolume; } 
        set 
        { 
            if (value.GetType() == typeof(float))
            {
                _BGVolume = value;
                BG.volume = _BGVolume;
            }    
        }
    }
    private float _FXVolume;
    public float FXVolume
    {
        get { return _FXVolume; }
        set
        {
            if (value.GetType() == typeof(float))
            {
                _FXVolume = value;
                FX.volume = _FXVolume;
            }
        }
    }
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
    public void ChangeBGMusic(AudioClip newMusic)
    {
        BG.clip = newMusic;
        BG.Play();
    }
}
