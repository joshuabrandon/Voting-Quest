using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Answer
{
    public int answerId;
    public string answerText;
    public int competencyScore;
    public int personalityScore;

    public Answer(int answerId, string answerText, int competencyScore, int personalityScore)
    {
        this.answerId = answerId;
        this.answerText = answerText;
        this.competencyScore = competencyScore;
        this.personalityScore = personalityScore;
    }
}