using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class QuestionDisplay : MonoBehaviour
{
    [SerializeField] private InterviewManager interviewManager;
    [SerializeField] private TextMeshProUGUI interviewQuestionText;

    //void Start()
    //{
    //    DisplayQuestionText();
    //}
    //
    //private void DisplayQuestionText()
    //{
    //    interviewQuestionText.text = interviewManager.currentInterviewQuestion.questionText;
    //}
}
