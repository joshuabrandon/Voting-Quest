using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class ScoreBar : MonoBehaviour
{
    public Slider slider;
    public Gradient gradient;
    public Image fill;

    public void SetMaxScore(int score)
    {
        slider.maxValue = score;
    }

    public void SetMinScore(int score)
    {
        slider.minValue = score;
    }

    public void SetScore(int score)
    {
        slider.value = score;

        fill.color = gradient.Evaluate(slider.normalizedValue);
    }

    public void ResetScore(int score)
    {
        slider.value = 0;
    }
}
