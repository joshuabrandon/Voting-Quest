using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnswerCardEffect : MonoBehaviour
{
    private AnswerCard _card;

    [Header("Prefab Elements")] // references from objects in the card prefab
    [SerializeField] private int _competencyScore;
    [SerializeField] private int _personalityScore;

    private void Awake()
    {
        _card = GetComponent<AnswerCard>();
        SetCardEffect();
    }

    private void OnValidate()
    {
        Awake();
    }

    public void SetCardEffect()
    {
        if (_card != null && _card.CardData != null)
        {
            SetCardScores();
        }
    }

    private void SetCardScores()
    {
        _competencyScore = (int)_card.CardData.CompetencyScore;
        _personalityScore = (int)_card.CardData.PersonalityScore;
    }

    public void ApplyCardScores()
    {
        GameManager.instance.competencyScore += _competencyScore;
        GameManager.instance.personalityScore += _personalityScore;
    }

    public void GoToNextQuestion()
    {
        InterviewDeck.instance.interviewQuestionIndex++;
        InterviewDeck.instance.SetupNextQuestion();
    }
}
