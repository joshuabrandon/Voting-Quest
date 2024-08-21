using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;


public class ApplicantCardUI : MonoBehaviour
{
    private ApplicantCard _card;

    [Header("Prefab Elements")] // references from objects in the card prefab
    [SerializeField] private TextMeshProUGUI _applicantName;
    [SerializeField] private Image _applicantImage;
    [SerializeField] private TextMeshProUGUI _applicantBio;
    [SerializeField] private TextMeshProUGUI _applicantRarity;
    [SerializeField] private TextMeshProUGUI _applicantTraits;

    private void Awake()
    {
        _card = GetComponent<ApplicantCard>();
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
            SetCardImages();
        }
    }

    private void SetCardTexts()
    {
        _applicantName.text = _card.CardData.applicantName;
        _applicantBio.text = _card.CardData.applicantBio;
        _applicantRarity.text = _card.CardData.applicantRarity.ToString();
        string[] traits = _card.CardData.applicantTraits.ToString().Replace("_", " ").Split(",");
        System.Array.Sort(traits);
        string traitText = string.Join("\n", traits.Select(trait => trait.Trim()));
        _applicantTraits.text = traitText;
    }

    private void SetCardImages()
    {
        _applicantImage.sprite = _card.CardData.applicantProfilePicture;
    }
}
