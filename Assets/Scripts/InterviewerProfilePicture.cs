using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InterviewerProfilePicture : MonoBehaviour
{
    [SerializeField] private InterviewDeck _interviewDeck;
    [SerializeField] private Sprite interviewerSprite;

    private void Start()
    {
        SetInterviewerProfilePicture();
    }

    private void SetInterviewerProfilePicture()
    {
        interviewerSprite = _interviewDeck._interviewerProfilePicture;
        this.gameObject.GetComponent<Image>().sprite = interviewerSprite;
    }
}
