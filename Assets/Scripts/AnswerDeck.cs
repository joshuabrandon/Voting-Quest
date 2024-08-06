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

    public void PopulateAnswerGrid()
    {
        _answerCards = _interviewDeck._answerCards;
        foreach (var answer in _answerCards)
        {
            AnswerCard card = Instantiate(_answerCardPrefab, _answerCardArea.transform);
            card.SetUp(answer);
        }
    }

    public void ClearAnswerGrid()
    {
        GameObject[] _answers = GameObject.FindGameObjectsWithTag("AnswerCard");
        foreach (GameObject _answer in _answers) GameObject.Destroy(_answer);
    }
}
