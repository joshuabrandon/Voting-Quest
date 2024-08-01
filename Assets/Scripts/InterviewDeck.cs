using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InterviewDeck : MonoBehaviour
{
    private void Awake()
    {
        // typical singleton declaration
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public static InterviewDeck Instance { get; private set; }

    [SerializeField] private ScriptableJob _activeJob;
    [SerializeField] private List<ScriptableInterviewQuestion> _interviewQuestions;
    [SerializeField] private InterviewCard _questionCardPrefab;
    [SerializeField] private GameObject _questionCardArea;

    private ScriptableInterviewQuestion currentInterviewQuestion;

    public List<ScriptableAnswerCard> _answerCards;

    private void Start()
    {
        BuildInterviewDeck();
        ChooseInterviewQuestion();
        InstantiateInterviewQuestion();
        PopulateInterviewAnswers();
    }

    private void BuildInterviewDeck()
    {
        _interviewQuestions = _activeJob.InterviewQuestions;
    }

    private void ChooseInterviewQuestion()
    {
        currentInterviewQuestion = _interviewQuestions[0];
    }

    private void InstantiateInterviewQuestion()
    {
        InterviewCard card = Instantiate(_questionCardPrefab, _questionCardArea.transform);
        card.SetUp(currentInterviewQuestion);
    }
    
    private void PopulateInterviewAnswers()
    {
        _answerCards = currentInterviewQuestion.InterviewAnswers;
    }
}
