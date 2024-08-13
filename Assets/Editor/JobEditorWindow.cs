using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEditor;
using UnityEngine;
using static PlasticGui.WorkspaceWindow.CodeReview.ReviewChanges.Summary.CommentSummaryData;

public class JobEditorWindow : EditorWindow
{
    private static JobEditorWindowData data;

    [InitializeOnLoadMethod]
    private static void OnLoad()
    {
        if (!data)
        {
            data = AssetDatabase.LoadAssetAtPath<JobEditorWindowData>("Assets/Scriptable Objects/JobEditorWindowData.asset");
        }
        if (data) return;

        data = CreateInstance<JobEditorWindowData>();

        AssetDatabase.CreateAsset(data, "Assets/Scriptable Objects/JobEditorWindowData.asset");
        AssetDatabase.Refresh();
    }

    private List<Job> jobs = new List<Job>();

    private Vector2 scrollPos;

    private const string JobDataDefaultPath = "Assets/Prefabs/Jobs/";

    [MenuItem("Tools/Job Editor Window")]
    public static void ShowWindow()
    {
        GetWindow<JobEditorWindow>("Job Editor Window");
    }

    private void OnGUI()
    {
        var serializedObject = new SerializedObject(data);
        serializedObject.Update();
        var jobId = serializedObject.FindProperty("jobId");
        var questionId = serializedObject.FindProperty("questionId");
        var answerId = serializedObject.FindProperty("answerId");
        
        EditorGUILayout.LabelField("Job Definition Editor", EditorStyles.boldLabel);
        scrollPos = EditorGUILayout.BeginScrollView(scrollPos, GUILayout.Width(position.width), GUILayout.Height(position.height - 50));

        GreenColor();
        if (GUILayout.Button("Add Job"))
        {
            Job newJob = ScriptableObject.CreateInstance<Job>();
            newJob.Initialize(jobId.intValue, "New Job", "", JobLevel.Entry, null, new List<Question>());
            jobs.Add(newJob);
            jobId.intValue += 1;
        }
        ResetColor();


        for (int i = 0; i < jobs.Count; i++)
        {
            BlueColor();
            EditorGUILayout.BeginVertical("box");
            ResetColor();
            EditorGUILayout.LabelField($"Job ID: {jobs[i].jobId}");
            AssignJobVariables(jobs[i]);

            EditorGUI.indentLevel++;
            GreenColor();
            if (GUILayout.Button("Add Interview Question"))
            {
                jobs[i].questionList.Add(new Question(questionId.intValue, "New Question", new List<Answer>()));
                questionId.intValue += 1;
            }
            ResetColor();

            for (int j = 0; j < jobs[i].questionList.Count; j++)
            {
                EditorGUILayout.BeginVertical("box");
                EditorGUILayout.LabelField($"Question ID: {jobs[i].questionList[j].questionId}");
                AssignQuestionVariables(jobs[i].questionList[j]);

                EditorGUI.indentLevel++;
                GreenColor();
                if (GUILayout.Button("Add Interview Answer"))
                {
                    jobs[i].questionList[j].answerList.Add(new Answer(answerId.intValue, "New Answer", 0, 0));
                    answerId.intValue += 1;
                }
                ResetColor();

                for (int k = 0; k < jobs[i].questionList[j].answerList.Count; k++)
                {
                    EditorGUILayout.BeginVertical();
                    EditorGUILayout.LabelField($"Answer ID: {jobs[i].questionList[j].answerList[k].answerId}");
                    AssignAnswerVariables(jobs[i].questionList[j].answerList[k]);

                    RedColor();
                    if (GUILayout.Button("Remove Interview Answer ID: " + jobs[i].questionList[j].answerList[k].answerId))
                    {
                        jobs[i].questionList[j].answerList.RemoveAt(k);
                    }
                    ResetColor();
                    EditorGUILayout.EndVertical();
                }
                EditorGUI.indentLevel--;

                RedColor();
                if (GUILayout.Button("Remove Interview Question ID: " + jobs[i].questionList[j].questionId))
                {
                    jobs[i].questionList.RemoveAt(j);
                }
                ResetColor();
                EditorGUILayout.EndVertical();
            }
            EditorGUI.indentLevel--;

            RedColor();
            if (GUILayout.Button("Remove Job ID: " + jobs[i].jobId))
            {
                jobs.RemoveAt(i);
            }
            ResetColor();

            if (GUILayout.Button("Save Job"))
            {
                SaveJob(jobs[i]);
            }
            EditorGUILayout.EndVertical();
        }

        if (GUILayout.Button("Clear All"))
        {
            jobs.Clear();
        }

        serializedObject.ApplyModifiedProperties();
        EditorGUILayout.EndScrollView();
    }

    private void AssignJobVariables(Job job)
    {
        job.jobName = EditorGUILayout.TextField("Job Title", job.jobName);
        EditorGUILayout.PrefixLabel("Job Description");
        job.jobDescription = EditorGUILayout.TextArea(job.jobDescription, GUILayout.Width(position.width - 30), GUILayout.Height(50));
        job.interviewerSprite = EditorGUILayout.ObjectField("Interviewer Sprite", job.interviewerSprite, typeof(Sprite), false) as Sprite;
    }

    private void AssignQuestionVariables(Question question)
    {
        EditorGUILayout.PrefixLabel("Question Text");
        question.questionText = EditorGUILayout.TextArea(question.questionText, GUILayout.Width(position.width - 30), GUILayout.Height(50));
    }
    private void AssignAnswerVariables(Answer answer) 
    {
        EditorGUILayout.PrefixLabel("Answer Text");
        answer.answerText = EditorGUILayout.TextArea(answer.answerText, GUILayout.Width(position.width - 30), GUILayout.Height(50));
        answer.competencyScore = EditorGUILayout.IntSlider("Competency Score", answer.competencyScore, -10, 10);
        answer.personalityScore = EditorGUILayout.IntSlider("Personality Score", answer.personalityScore, -10, 10);
    }

    private void SaveJob(Job job) // look at CreateNewCard() in demo script
    {
        string path = $"Assets/Prefabs/Jobs/{job.jobName}.asset";

        Job newJob = ScriptableObject.CreateInstance<Job>();
        newJob.Initialize(job.jobId, job.jobName, job.jobDescription, job.jobLevel, job.interviewerSprite, new List<Question>(job.questionList));

        AssetDatabase.CreateAsset(newJob, path);
        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();

        Debug.Log($"Group saved to {path}");
    }

    private void BlueColor()
    {
        GUI.backgroundColor = Color.blue;
    }
    private void GreenColor()
    {
        GUI.backgroundColor = Color.green;
    }

    private void RedColor()
    {
        GUI.backgroundColor = Color.red;
    }

    private void ResetColor()
    {
        GUI.backgroundColor = Color.white;
    }
}
