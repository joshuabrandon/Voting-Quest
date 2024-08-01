using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIDisplay : MonoBehaviour
{
    public TextMeshProUGUI displayCompetencyScore;
    public TextMeshProUGUI displayPersonalityScore;
    
    public void Update()
    {
        UpdateCompetencyScoreDisplay();
        UpdatePersonalityScoreDisplay();
    }
    
    private void UpdateCompetencyScoreDisplay()
    {
        displayCompetencyScore.text = GameManager.instance.competencyScore.ToString();
    }
    
    private void UpdatePersonalityScoreDisplay()
    {
        displayPersonalityScore.text = GameManager.instance.personalityScore.ToString();
    }
}
