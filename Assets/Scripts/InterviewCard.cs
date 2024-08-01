using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(InterviewCardUI))]
public class InterviewCard : MonoBehaviour
{
    [field: SerializeField] public ScriptableInterviewQuestion CardData { get; private set; }

    public void SetUp(ScriptableInterviewQuestion data)
    {
        CardData = data;
        GetComponent<InterviewCardUI>().SetCardUI();
    }
}
