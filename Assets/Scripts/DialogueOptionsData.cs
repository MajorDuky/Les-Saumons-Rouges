using System;
using System.Collections.Generic;

[Serializable]
public struct Answers
{
    public int answerId;
    public string answerText;
    public int answerKarma;
}

[Serializable]
public struct AnswersData
{
    public List<Answers> answers;
}

[Serializable]
public class DialogueOptionsData
{
    public List<AnswersData> dialogueOptionsData;
}
