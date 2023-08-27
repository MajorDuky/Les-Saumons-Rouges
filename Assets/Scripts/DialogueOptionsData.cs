using System;
using System.Collections;
using System.Collections.Generic;

[Serializable]
public struct Answers
{
    public int answerId;
    public string answerText;
    public int answerKarma;
}
[Serializable]
public class DialogueOptionsData
{
    public int questionId;
    public List<Answers> answers;
}
