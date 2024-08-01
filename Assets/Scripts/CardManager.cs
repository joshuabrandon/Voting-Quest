using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CardManager : MonoBehaviour
{
    //private List<InterviewAnswer> interviewAnswers;

    public TextMeshProUGUI interviewAnswerText;

    private int CompetencyDelta;
    private int PersonalityDelta;

    void Update()
    {
        //GetInterviewAnswers();
        //UpdateAnswerText();
    }

    private void GetInterviewAnswers()
    {
        //interviewAnswers = GameManager.instance.interviewAnswers;
    }

    //private void UpdateAnswerText()
    //{
    //    interviewAnswerText.text = interviewAnswers[0].questionResponse;
    //}

    private void UpdateCompetencyScore()
    {
        GameManager.instance.competencyScore = GameManager.instance.competencyScore + Random.Range(-10, 11);
        GameManager.instance.LoseCondition();
    }

    private void UpdatePersonalityScore()
    {
        GameManager.instance.personalityScore = GameManager.instance.personalityScore + Random.Range(-10, 11);
        GameManager.instance.LoseCondition();
    }

}
