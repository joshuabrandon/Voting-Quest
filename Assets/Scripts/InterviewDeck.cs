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

    [SerializeField] private Job _activeJob;
    [SerializeField] private List<Question> _questions;
    [SerializeField] private AnswerDeck _answerDeck;
    [SerializeField] private InterviewCard _questionCardPrefab;
    [SerializeField] private GameObject _questionCardArea;

    private Question currentInterviewQuestion;
    public int interviewQuestionIndex = 0; // modify this to start on different questions, or have list be randomized

    //public List<ScriptableAnswerCard> _answerCards;

    public List<Answer> _answers;
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
        _questions = _activeJob.questionList;
    }

    private void ChooseInterviewQuestion()
    {
        currentInterviewQuestion = _questions[interviewQuestionIndex];
    }

    private void InstantiateInterviewQuestion()
    {
        InterviewCard card = Instantiate(_questionCardPrefab, _questionCardArea.transform);
        card.SetUp(currentInterviewQuestion);
    }
    
    private void PopulateInterviewAnswers()
    {
        _answers = currentInterviewQuestion.answerList;
    }

    private void GetInterviewerProfilePicture()
    {
        _interviewerProfilePicture = _activeJob.interviewerSprite;
    }

    public void SetupNextQuestion()
    {
        if (interviewQuestionIndex >= _questions.Count)
        {
            // End run
            _answerDeck.ClearAnswerGrid();
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
            _answerDeck.ClearAnswerGrid();
            // Instantiate new interview answer cards
            _answerDeck.PopulateAnswerGrid();
        }
    }


}
