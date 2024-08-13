using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class JobSelectionMenu : MonoBehaviour
{
    private List<Job> allJobs;
    [SerializeField] private GameObject jobSelectionBlock;
    [SerializeField] private List<Job> entryJobs;
    [SerializeField] private List<Job> midJobs;
    [SerializeField] private List<Job> seniorJobs;

    [SerializeField] private GameObject jobSelectionArea;

    private void Start()
    {
        GetJobs();
        InstantiateJobSelectionBlocks(entryJobs, jobSelectionArea); // maybe make this based on a trigger?
    }

    private void Update()
    {
        
    }

    private void GetJobs()
    {
        allJobs = GameManager.instance.allJobs;
        entryJobs = allJobs.Where(job => job.jobLevel == JobLevel.Entry).OrderBy(job => job.jobId).ToList();
        midJobs = allJobs.Where(job => job.jobLevel == JobLevel.Mid).OrderBy(job => job.jobId).ToList();
        seniorJobs = allJobs.Where(job => job.jobLevel == JobLevel.Senior).OrderBy(job => job.jobId).ToList();
    }

    private void InstantiateJobSelectionBlocks(List<Job> jobs, GameObject parentArea)
    {
        for (int i = 0; i < jobs.Count; i++)
        {
            jobSelectionBlock.GetComponent<JobSelectionBlock>().InstantiateJobSelectionBlock(jobs[i], parentArea);
        }
    }

    private void ClearDisplay()
    {
        GameObject[] _blocks = GameObject.FindGameObjectsWithTag("JobSelectionBlock");
        foreach (GameObject _block in _blocks) GameObject.Destroy(_block);
    }

    public void DisplayEntryJobs()
    {
        ClearDisplay();
        InstantiateJobSelectionBlocks(entryJobs, jobSelectionArea);
    }

    public void DisplayMidJobs()
    {
        ClearDisplay();
        InstantiateJobSelectionBlocks(midJobs, jobSelectionArea);
    }

    public void DisplaySeniorJobs()
    {
        ClearDisplay();
        InstantiateJobSelectionBlocks(seniorJobs, jobSelectionArea);
    }

    // add button to the JobSelectionBlock prefab
    // add public methods to this class to set selected Job ID for the run
}
