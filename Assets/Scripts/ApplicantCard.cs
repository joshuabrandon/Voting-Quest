using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ApplicantCardUI))]
[RequireComponent(typeof(ApplicantCardEffect))]
public class ApplicantCard : MonoBehaviour
{
    [field: SerializeField] public Applicant CardData { get; private set; }

    public void SetUp(Applicant data)
    {
        CardData = data;
        GetComponent<ApplicantCardUI>().SetCardUI();
    }
}
