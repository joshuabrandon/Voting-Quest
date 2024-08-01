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
    [SerializeField] private InterviewCard _cardPrefab;

    [SerializeField] private GameObject _cardArea;

    private void Start()
    {
        BuildInterviewDeck();
        InstantiateInterviewQuestion();
    }

    private void BuildInterviewDeck()
    {
        _interviewQuestions = _activeJob.InterviewQuestions;
    }

    private void InstantiateInterviewQuestion()
    {
        InterviewCard card = Instantiate(_cardPrefab, _cardArea.transform);
        card.SetUp(_interviewQuestions[0]);
    }
}
