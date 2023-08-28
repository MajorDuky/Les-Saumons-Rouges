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
    private int _currentDialogue;
    public int CurrentDialogue
    {
        get { return _currentDialogue; }
        set { if (value.GetType() == typeof(int)) { _currentDialogue = value; }; }
    }
    private int karmaModifier;
    [SerializeField] private DialogueData dialogueData;
    private DialogueOptionsData dialogueOptionsData;
    private bool isAnsweringAQuestion;
    public bool IsAnsweringAQuestion
    {
        get { return isAnsweringAQuestion; }
        set { if(value.GetType() == typeof(bool)) { isAnsweringAQuestion = value; }; }
    }

    // Start is called before the first frame update
    void Start()
    {
        if (GameManager.Instance.DialogueId != -1)
        {
            CurrentDialogue = GameManager.Instance.DialogueId;
            PlayerKarma = GameManager.Instance.PlayerKarma;
        }
        else
        {
            CurrentDialogue = -1;
            PlayerKarma = 10;
        }
        dialogueJsonPath = Application.dataPath + "/JSon/dialoguedata.json";
        string dialogueJson = File.ReadAllText(dialogueJsonPath);
        dialogueOptionsJsonPath = Application.dataPath + "/JSon/dialogueoptionsdata.json";
        string dialogueOptionsJson = File.ReadAllText(dialogueOptionsJsonPath);

        if (dialogueJson != null)
        {
            dialogueData = JsonUtility.FromJson<DialogueData>(dialogueJson);
        }

        if (dialogueOptionsJson != null)
        {
            dialogueOptionsData = JsonUtility.FromJson<DialogueOptionsData>(dialogueOptionsJson);
        }
        DialogueHandler();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !isAnsweringAQuestion)
        {
            DialogueHandler();
        }
    }

    public void DialogueHandler()
    {
        if (PlayerKarma >= 50)
        {
            karmaModifier = 1;
        }
        else
        {
            karmaModifier = 0;
        }

        DialogueStructure dialogue = dialogueData.dialogue[CurrentDialogue + 1];
        
        CurrentDialogue += 1;
        int idDialogueToFire = dialogue.dialogueStructure.Count > 1 ? karmaModifier : 0;
        DialogueDetails dialogueDetails = dialogue.dialogueStructure[idDialogueToFire];
        StartCoroutine(MainUIHandler.LaunchNewTextCoroutine(dialogueDetails.characterDialogue));
        MainUIHandler.ChangeBackgroundSprite(dialogueDetails.backgroundSpriteId);
        MainUIHandler.HandleActiveSprites(dialogueDetails.characterPosition);
        MainUIHandler.ChangeCharacterSprite(dialogueDetails.characterSpriteId, dialogueDetails.characterPosition);
        MainUIHandler.HandleActiveChoice(dialogueDetails.isQuestion);
        if (dialogueDetails.isQuestion)
        {
            MainUIHandler.GenerateDialogueChoices(dialogueOptionsData.dialogueOptionsData[dialogueDetails.questionId].answers);
            isAnsweringAQuestion = true;
        }
    }
}
