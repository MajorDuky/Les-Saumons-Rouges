using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    [SerializeField] private string dialogueJsonPath;
    [SerializeField] private MainUIHandler MainUIHandler;
    private float _playerKarma;
    public float PlayerKarma
    {
        get { return _playerKarma; }
        set { if (value.GetType() == typeof(float)) { _playerKarma = value; }; }
    }
    // Start is called before the first frame update
    void Start()
    {
        dialogueJsonPath = Application.dataPath + "/JSon/dialoguedata.json";
        string dialogueJson = File.ReadAllText(dialogueJsonPath);
        if(dialogueJson != null)
        {
            DialogueData dialogueData = JsonUtility.FromJson<DialogueData>(dialogueJson);
            Debug.Log(dialogueData);
            DialogueDetails dialogue = dialogueData.dialogueDetails[0];
            Debug.Log(dialogue.characterDialogue);
            StartCoroutine(MainUIHandler.LaunchNewTextCoroutine(dialogue.characterDialogue));
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
