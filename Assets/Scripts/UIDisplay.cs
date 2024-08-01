using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIDisplay : MonoBehaviour
{
    public TextMeshProUGUI displayCompetencyScore;
    public TextMeshProUGUI displayPersonalityScore;
    public Sprite sprite;
    public GameObject interviewerImage;

    //public void Start()
    //{
    //    GetInterviewerSprite();
    //}
    //
    //public void Update()
    //{
    //    UpdateCompetencyScoreDisplay();
    //    UpdatePersonalityScoreDisplay();
    //    UpdateInterviewerSprite();
    //}
    //
    //private void UpdateCompetencyScoreDisplay()
    //{
    //    displayCompetencyScore.text = GameManager.instance.competencyScore.ToString();
    //}
    //
    //private void UpdatePersonalityScoreDisplay()
    //{
    //    displayPersonalityScore.text = GameManager.instance.personalityScore.ToString();
    //}
    //
    //private void GetInterviewerSprite()
    //{
    //    sprite = GameManager.instance.job.interviewerSprite;
    //}
    //
    //private void UpdateInterviewerSprite()
    //{
    //    interviewerImage.GetComponent<Image>().sprite = sprite;
    //}
}
