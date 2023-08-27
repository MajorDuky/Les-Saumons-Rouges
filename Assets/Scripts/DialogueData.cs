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
public class DialogueData
{
    public int dialogueId;
    public int dialogueKarma;
    public List<DialogueDetails> dialogueDetails;
}
