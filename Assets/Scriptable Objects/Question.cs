using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Question
{
    public int questionId;
    public string questionText;
    public List<Answer> answerList;

    public Question(int questionId, string questionText, List<Answer> answerList)
    {
        this.questionId = questionId;
        this.questionText = questionText;
        this.answerList = answerList;
    }
}
