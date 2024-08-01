using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Answer", menuName = "Scriptable Objects/Interview Answer")]
public class ScriptableAnswerCard : ScriptableObject
{
    [field: SerializeField, TextArea] public string AnswerText { get; private set; }
    [field: SerializeField] public DecisionEffect CompetencyScore { get; private set; }
    [field: SerializeField] public DecisionEffect PersonalityScore { get; private set; }
    // set this as a single image in the future
    [field: SerializeField] public Sprite CompetencyEmblem { get; private set; }
    [field: SerializeField] public Sprite CompetencyIndicator { get; private set; }
    [field: SerializeField] public Sprite PersonalityEmblem { get; private set; }
    [field: SerializeField] public Sprite PersonalityIndicator { get; private set; }
}
