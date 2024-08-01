using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InterviewDeck : MonoBehaviour
{
    private void Awake()
    {
        // typical singleton declaration
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public static InterviewDeck instance { get; private set; }

    [SerializeField] private ScriptableJob _activeJob;
    [SerializeField] private AnswerDeck _answerDeck;
    [SerializeField] private List<ScriptableInterviewQuestion> _interviewQuestions;
    [SerializeField] private InterviewCard _questionCardPrefab;
    [SerializeField] private GameObject _questionCardArea;

    private ScriptableInterviewQuestion currentInterviewQuestion;
    public int interviewQuestionIndex = 0;

    public List<ScriptableAnswerCard> _answerCards;

    public Sprite _interviewerProfilePicture;

    private void Start()
    {
        BuildInterviewDeck();
        ChooseInterviewQuestion();
        InstantiateInterviewQuestion();
        PopulateInterviewAnswers();
        GetInterviewerProfilePicture();
    }

    private void BuildInterviewDeck()
    {
        _interviewQuestions = _activeJob.InterviewQuestions;
    }

    private void ChooseInterviewQuestion()
    {
        currentInterviewQuestion = _interviewQuestions[interviewQuestionIndex];
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

    private void GetInterviewerProfilePicture()
    {
        _interviewerProfilePicture = _activeJob.InterviewerSprite;
    }

    public void SetupNextQuestion()
    {
        if (interviewQuestionIndex >= _interviewQuestions.Count)
        {
            // End run
            Debug.Log("Out of questions.");
            StartCoroutine (GameManager.instance.EndRun()); // read about StartCoroutine
        }
        else
        {
            // Delete existing question object
            Destroy(GameObject.FindGameObjectWithTag("QuestionText"));
            // Instantiate new question object
            ChooseInterviewQuestion();
            InstantiateInterviewQuestion();
            // Update existing interview answers list
            PopulateInterviewAnswers();
            // Delete existing interview answer cards
            GameObject[] _answers = GameObject.FindGameObjectsWithTag("AnswerCard");
            foreach(GameObject _answer in _answers) GameObject.Destroy(_answer);
            // Instantiate new interview answer cards
            _answerDeck.PopulateAnswerGrid();
        }
    }
}
