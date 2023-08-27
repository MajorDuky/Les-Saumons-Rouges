using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ChoiceComponent : MonoBehaviour
{
    public TMP_Text choice;
    private int _answerKarma;
    private DialogueManager _dialogueManager;

    private void Start()
    {
        _dialogueManager = GameObject.Find("DialogueManager").GetComponent<DialogueManager>();
    }
    public int AnswerKarma 
    { 
        get { return _answerKarma; }
        set { if (value.GetType() == typeof(int)) { _answerKarma = value; } }
    }

    public void OnChoiceClick()
    {
        _dialogueManager.PlayerKarma += AnswerKarma;
    }
}
