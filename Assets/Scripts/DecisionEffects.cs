using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecisionEffects : MonoBehaviour
{
    public DecisionEffect decisionEffect;
}

public enum DecisionEffect
{
    Best = 30,
    Better = 20,
    Good = 10,
    Neutral = 0,
    Bad = -10,
    Worse = -20,
    Worst = -30
}
