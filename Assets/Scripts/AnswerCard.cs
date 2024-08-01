using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AnswerCardUI))]
public class AnswerCard : MonoBehaviour
{
    [field: SerializeField] public ScriptableAnswerCard CardData { get; private set; }

    public void SetUp(ScriptableAnswerCard data)
    {
        CardData = data;
        GetComponent<AnswerCardUI>().SetCardUI();
    }
}
