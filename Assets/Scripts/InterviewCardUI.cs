using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InterviewCardUI : MonoBehaviour
{
    private InterviewCard _card;

    [Header("Prefab Elements")] // references from objects in the card prefab
    [SerializeField] private TextMeshProUGUI _questionText;

    private void Awake()
    {
        _card = GetComponent<InterviewCard>();
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
            //SetCardImage();
        }
    }

    private void SetCardTexts()
    {
        _questionText.text = _card.CardData.QuestionText;
    }
}
