using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class JobSelectionBlock : MonoBehaviour
{
    [Header("Prefab Elements")]
    [SerializeField] private Image jobImage;
    [SerializeField] private TextMeshProUGUI jobName;
    [SerializeField] private TextMeshProUGUI jobDescription;
    [SerializeField] private TextMeshProUGUI earnings;
    [SerializeField] private TextMeshProUGUI applicantStatus;

    [SerializeField] private Job activeJob;

    public void InstantiateJobSelectionBlock(Job job, GameObject parentArea)
    {
        SetCardTexts(job);
        SetCardImages(job);
        SetCardData(job);
        Instantiate(this, parentArea.transform);
    }

    private void SetCardTexts(Job job)
    {
        jobName.text = job.jobName;
        jobDescription.text = job.jobDescription;
        System.Random rnd = new System.Random();
        earnings.text = rnd.Next(10,101).ToString(); // need to implement this in Job class
        applicantStatus.text = "First Time Applicant!"; // need to update based on unlock/tracking system
    }

    private void SetCardImages(Job job)
    {
        //jobImage.sprite = job.jobImage; // need to implement this in Job class
    }

    private void SetCardData(Job job)
    {
        activeJob = job;
    }

    public void SetActiveJob()
    {
        GameManager.instance.activeJob = activeJob;
    }
}
