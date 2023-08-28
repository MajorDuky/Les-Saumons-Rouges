using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEditor.XR;

public class GameManager : MonoBehaviour
{   
    public static GameManager Instance { get; private set; }
    [SerializeField] private AudioSource BG;
    [SerializeField] private AudioSource FX;
    [SerializeField] private string savePath = "/savefile.json";
    private int dialogueId = 0;
    public int DialogueId
    {
        get { return dialogueId; }
        set { if (value.GetType() == typeof(int)) { dialogueId = value; } }
    }
    private int playerKarma;
    public int PlayerKarma
    {
        get { return playerKarma; }
        set { if (value.GetType() == typeof(int)) { playerKarma = value; } }
    }

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

    public bool isFreshlyStarted;
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

    public void Save(int dialogueId, int playerKarma)
    {
        SaveData data = new SaveData();
        data.dialogueId = dialogueId;
        data.playerKarma = playerKarma;

        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + savePath, json);
    }

    public void Load()
    {
        string jsonPath = Application.persistentDataPath + savePath;
        string json = File.ReadAllText(jsonPath);
        SaveData data = JsonUtility.FromJson<SaveData>(json);
        dialogueId = data.dialogueId;
        playerKarma = data.playerKarma;
    }
}
