using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(InterviewCardUI))]
public class InterviewCard : MonoBehaviour
{
    [field: SerializeField] public Question CardData { get; private set; }

    public void SetUp(Question data)
    {
        CardData = data;
        GetComponent<InterviewCardUI>().SetCardUI();
    }
}
