using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    [SerializeField] private string dialogueJsonPath;
    [SerializeField] private string dialogueOptionsJsonPath;
    [SerializeField] private MainUIHandler MainUIHandler;
    private int _playerKarma;
    public int PlayerKarma
    {
        get { return _playerKarma; }
        set { if (value.GetType() == typeof(int)) { _playerKarma = value; }; }
    }
    private int currentDialogue;

    // Start is called before the first frame update
    void Start()
    {
        dialogueJsonPath = Application.dataPath + "/JSon/dialoguedata.json";
        string dialogueJson = File.ReadAllText(dialogueJsonPath);

        dialogueOptionsJsonPath = Application.dataPath + "/JSon/dialogueoptionsdata.json";
        string dialogueOptionsJson = File.ReadAllText(dialogueOptionsJsonPath);

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
