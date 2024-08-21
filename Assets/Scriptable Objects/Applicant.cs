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
    public ApplicantTraits applicantTraits;
    public Sprite applicantProfilePicture;

    public void Initialize(int applicantId, string applicantName, string applicantBio, ApplicantRarity applicantRarity, ApplicantTraits applicantTraits, Sprite applicantProfilePicture)
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

[System.Flags]
public enum ApplicantTraits
{
    None            = 0,
    Funny           = 1 << 0,
    Charismatic     = 1 << 1,
    Arrogant        = 1 << 2,
    Lazy            = 1 << 3,
    Quick_Learner   = 1 << 4,
}
