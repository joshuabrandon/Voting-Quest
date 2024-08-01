using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AnswerCardUI : MonoBehaviour
{
    private AnswerCard _card;

    [Header("Prefab Elements")] // references from objects in the card prefab
    [SerializeField] private TextMeshProUGUI _answerText;
    [SerializeField] private Image _competencyEmblem;
    [SerializeField] private Image _competencyIndicator;
    [SerializeField] private Image _personalityEmblem;
    [SerializeField] private Image _personalityIndicator;

    private void Awake()
    {
        _card = GetComponent<AnswerCard>();
        SetCardUI();
    }

    private void OnValidate()
    {
        Awake();
    }

    public void SetCardUI()
    {
        if (_card != null && _card.CardData != null)
        {
            SetCardTexts();
            SetCardImage();
        }
    }

    private void SetCardTexts()
    {
        _answerText.text = _card.CardData.AnswerText;
    }

    private void SetCardImage()
    {
        _competencyEmblem.sprite = _card.CardData.CompetencyEmblem;
        _competencyIndicator.sprite = _card.CardData.CompetencyIndicator;
        _personalityEmblem.sprite = _card.CardData.PersonalityEmblem;
        _personalityIndicator.sprite = _card.CardData.PersonalityIndicator;
    }
}
