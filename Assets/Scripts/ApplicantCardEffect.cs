using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplicantCardEffect : MonoBehaviour
{
    private ApplicantCard _card;

    //[Header("Prefab Elements")] // references from objects in the card prefab

    private void Awake()
    {
        _card = GetComponent<ApplicantCard>();
        //SetCardEffect();
    }

    private void OnValidate()
    {
        Awake();
    }

    //public void SetCardEffect()
    //{
    //    if (_card != null && _card.CardData != null)
    //    {
    //        
    //    }
    //}

    public void SetActiveApplicant()
    {
        GameManager.instance.activeApplicant = _card.CardData;
    }
}
