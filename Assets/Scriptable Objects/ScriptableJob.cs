using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Job", menuName = "Scriptable Objects/Job")]
public class ScriptableJob : ScriptableObject
{
    [field: SerializeField] public string JobName { get; private set; }
    [field: SerializeField, TextArea] public string JobDescription { get; private set; }
    [field: SerializeField] public List<ScriptableInterviewQuestion> InterviewQuestions { get; private set; }
    [field: SerializeField] public Sprite InterviewerSprite { get; private set; }
}
