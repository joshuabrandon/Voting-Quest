using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIDisplay : MonoBehaviour
{
    public ScoreBar competencyScoreBar;
    public ScoreBar personalityScoreBar;

    private void Update()
    {
        UpdateScoreDisplay();
    }
    
    //private void UpdateCompetencyScoreDisplay()
    //{
    //    displayCompetencyScore.text = GameManager.instance.competencyScore.ToString();
    //}
    //
    //private void UpdatePersonalityScoreDisplay()
    //{
    //    displayPersonalityScore.text = GameManager.instance.personalityScore.ToString();
    //}

    private void UpdateScoreDisplay()
    {
        competencyScoreBar.SetScore(GameManager.instance.competencyScore);
        personalityScoreBar.SetScore(GameManager.instance.personalityScore);
    }
}
