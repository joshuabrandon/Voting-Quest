using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(InterviewDeck))]
public class AnswerDeck : MonoBehaviour
{
    [SerializeField] private InterviewDeck _interviewDeck;
    [SerializeField] private AnswerCard _answerCardPrefab;
    [SerializeField] private GameObject _answerCardArea;

    private List<ScriptableAnswerCard> _answerCards;

    private void Start()
    {
        PopulateAnswerGrid();
    }

    private void PopulateAnswerGrid()
    {
        _answerCards = _interviewDeck._answerCards;
        foreach (var answer in _answerCards)
        {
            AnswerCard card = Instantiate(_answerCardPrefab, _answerCardArea.transform);
            card.SetUp(answer);
        }
    }
}
