using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Question", menuName = "Scriptable Objects/Interview Question")]
public class ScriptableInterviewQuestion : ScriptableObject
{
    [field: SerializeField, TextArea] public string QuestionText { get; private set; }
    [field: SerializeField] public List<ScriptableAnswerCard> InterviewAnswers { get; private set; }
}
