using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Job", menuName = "Scriptable Objects/New Job")]
public class Job : ScriptableObject
{
    public int jobId;
    public string jobName;
    public string jobDescription;
    public Sprite interviewerSprite;
    public List<Question> questionList;

    public void Initialize(int jobId, string jobName, string jobDescription, Sprite interviewerSprite, List<Question> questionList)
    {
        this.jobId = jobId;
        this.jobName = jobName;
        this.jobDescription = jobDescription;
        this.interviewerSprite = interviewerSprite;
        this.questionList = questionList;
    }
}
