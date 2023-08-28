using System;
using System.Collections;
using System.Collections.Generic;

[Serializable]
public struct DialogueDetails
{
    public string characterDialogue;
    public int characterSpriteId;
    public string characterPosition;
    public int backgroundSpriteId;
    public int musicId;
    public bool isQuestion;
    public int questionId;
}

[Serializable]
public struct DialogueStructure
{
    public List<DialogueDetails> dialogueStructure;
}

[Serializable]
public class DialogueData
{
    public List<DialogueStructure> dialogue;
}
