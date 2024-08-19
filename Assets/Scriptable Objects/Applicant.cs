using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// check if [System.Serializable] is needed, assume ScriptableObject is needed to work with editor window
[System.Serializable]
public class Applicant : ScriptableObject
{
    public int applicantId;
    public string applicantName;
    public string applicantBio;
    public ApplicantRarity applicantRarity;
    public List<ApplicantTraits> applicantTraits;
    public Sprite applicantProfilePicture;

    public void Initialize(int applicantId, string applicantName, string applicantBio, ApplicantRarity applicantRarity, List<ApplicantTraits> applicantTraits, Sprite applicantProfilePicture)
    {
        this.applicantId = applicantId;
        this.applicantName = applicantName;
        this.applicantBio = applicantBio;
        this.applicantRarity = applicantRarity;
        this.applicantTraits = applicantTraits;
        this.applicantProfilePicture = applicantProfilePicture;
    }
}

public enum ApplicantRarity
{
    Starter,
    Common,
    Rare,
    Legendary
}

public enum ApplicantTraits
{
    Funny,
    Charismatic,
    Arrogant,
    Lazy
}
