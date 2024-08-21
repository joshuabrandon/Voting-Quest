using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ApplicantEditorWindow : EditorWindow
{
    private static ApplicantEditorWindowData data;
    
    [InitializeOnLoadMethod]
    private static void OnLoad()
    {
        if (!data)
        {
            data = AssetDatabase.LoadAssetAtPath<ApplicantEditorWindowData>("Assets/Scriptable Objects/ApplicantEditorWindowData.asset");
        }
        if (data) return;
    
        data = CreateInstance<ApplicantEditorWindowData>();
    
        AssetDatabase.CreateAsset(data, "Assets/Scriptable Objects/ApplicantEditorWindowData.asset");
        AssetDatabase.Refresh();
    }

    private List<Applicant> applicants = new List<Applicant>();

    private Vector2 scrollPos;

    [MenuItem("Tools/Applicant Editor Window")]
    public static void ShowWindow()
    {
        GetWindow<ApplicantEditorWindow>("Applicant Editor Window");
    }

    private void OnGUI()
    {
        var serializedObject = new SerializedObject(data);
        serializedObject.Update();
        var applicantId = serializedObject.FindProperty("applicantId");

        EditorGUILayout.LabelField("Applicant Definition Editor", EditorStyles.boldLabel);
        scrollPos = EditorGUILayout.BeginScrollView(scrollPos, GUILayout.Width(position.width), GUILayout.Height(position.height - 50));

        GreenColor();
        if (GUILayout.Button("Add Applicant"))
        {
            Applicant newApplicant = ScriptableObject.CreateInstance<Applicant>();
            newApplicant.Initialize(applicantId.intValue, "New Applicant", "Applicant Bio", ApplicantRarity.Starter, ApplicantTraits.None, null);
            applicants.Add(newApplicant);
            applicantId.intValue += 1;
        }
        ResetColor();

        for (int i = 0; i < applicants.Count; i++)
        {
            BlueColor();
            EditorGUILayout.BeginVertical("box");
            ResetColor();
            EditorGUILayout.LabelField($"Applicant ID: {applicants[i].applicantId}");
            AssignApplicantVariables(applicants[i]);

            RedColor();
            if (GUILayout.Button("Remove Applicant ID: " + applicants[i].applicantId))
            {
                applicants.RemoveAt(i);
            }
            ResetColor();

            if (GUILayout.Button("Save Applicant"))
            {
                SaveApplicant(applicants[i]);
            }
            EditorGUILayout.EndVertical();
        }

        if (GUILayout.Button("Clear All"))
        {
            applicants.Clear();
        }

        serializedObject.ApplyModifiedProperties();
        EditorGUILayout.EndScrollView();
    }

    private void AssignApplicantVariables(Applicant applicant)
    {
        applicant.applicantName = EditorGUILayout.TextField("Applicant Name", applicant.applicantName);
        EditorGUILayout.PrefixLabel("Applicant Bio");
        applicant.applicantBio = EditorGUILayout.TextArea(applicant.applicantBio, GUILayout.Width(position.width - 30), GUILayout.Height(50));
        applicant.applicantProfilePicture = EditorGUILayout.ObjectField("Applicant Sprite", applicant.applicantProfilePicture, typeof(Sprite), false) as Sprite;
        applicant.applicantRarity = (ApplicantRarity)EditorGUILayout.EnumPopup("Applicant Rarity", applicant.applicantRarity);
        applicant.applicantTraits = (ApplicantTraits)EditorGUILayout.EnumFlagsField("Applicant Trait", applicant.applicantTraits);
    }

    private void SaveApplicant(Applicant app)
    {
        string path = $"Assets/Prefabs/Applicants/{app.applicantName}.asset";

        Applicant newApplicant = ScriptableObject.CreateInstance<Applicant>();
        newApplicant.Initialize(app.applicantId, app.applicantName, app.applicantBio, app.applicantRarity, app.applicantTraits, app.applicantProfilePicture);

        AssetDatabase.CreateAsset(newApplicant, path);
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
