using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AnswerDisplay : MonoBehaviour
{
    [SerializeField] private InterviewManager interviewManager;
    [SerializeField] private GameObject answerGrid;
    [SerializeField] private GameObject answerCardPrefab;

    //private List<InterviewAnswer> interviewAnswers;
    private GameObject answerCard;
    private TextMeshProUGUI answerText;

    //private void Start()
    //{
    //    InterviewAnswers();
    //    PopulateAnswerGrid();
    //}
    //
    //private void InterviewAnswers()
    //{
    //    interviewAnswers = interviewManager.currentInterviewQuestion.interviewAnswers;
    //}
    //
    //private void PopulateAnswerGrid()
    //{
    //    foreach (var answer in interviewAnswers)
    //    {
    //        GameObject answerCard = Instantiate(answerCardPrefab, new Vector3(0, 0, 0), Quaternion.identity);
    //        answerCard.transform.SetParent(answerGrid.transform, false);
    //        answerCard.GetComponentInChildren<TextMeshProUGUI>().text = answer.questionResponse;
    //        Debug.Log(answer);
    //    }
    //}
}
