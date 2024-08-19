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

    private Vector2 scrollPos;

    private const string ApplicantDataDefaultPath = "Assets/Prefabs/Applicants/";

    [MenuItem("Tools/Applicant Editor Window")]
    public static void ShowWindow()
    {
        GetWindow<ApplicantEditorWindow>("Applicant Editor Window");
    }

    private void OnGUI()
    {
        
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
}
