using System.Collections.Generic;
using UnityEngine;

public class ApplicantDeck : MonoBehaviour
{
    [SerializeField] private ApplicantCard _applicantCardPrefab;
    [SerializeField] private GameObject _applicantCardArea;

    [SerializeField] private List<Applicant> _allApplicantCards;
    private List<Applicant> _applicantCardPool;
    private List<Applicant> _displayedApplicantCards;

    private void Start()
    {
        GetApplicantPool();
        PopulateApplicantGrid(); // remove at some point, make based on an event
    }

    public void GetApplicantPool()
    {
        _applicantCardPool = _allApplicantCards;
        ShuffleList(_applicantCardPool);
        _displayedApplicantCards = new List<Applicant>(_applicantCardPool.GetRange(0, 3));
        _applicantCardPool.RemoveRange(0, 3);
    }

    public void PopulateApplicantGrid()
    {
        for (int i = 0; i < _displayedApplicantCards.Count; i++)
        {
            ApplicantCard card = Instantiate(_applicantCardPrefab, _applicantCardArea.transform);
            card.SetUp(_displayedApplicantCards[i]);
        }
    }

    public void RefreshApplicantGrid() // need to test this
    {
        ClearApplicantGrid();

        if (_applicantCardPool.Count > 3)
        {
            _displayedApplicantCards = new List<Applicant>(_applicantCardPool.GetRange(0, 3));
            _applicantCardPool.RemoveRange(0, 3);
        }
        else
        {
            GetApplicantPool();
            PopulateApplicantGrid();
        }
    }

    public void ClearApplicantGrid()
    {
        GameObject[] _applicants = GameObject.FindGameObjectsWithTag("ApplicantCard");
        foreach (GameObject _applicant in _applicants) GameObject.Destroy(_applicant);
    }

    static void ShuffleList<T>(List<T> list) // pull this into a static script if needed in other places
    {
        System.Random rng = new System.Random();
        int n = list.Count;
        while (n > 1)
        {
            n--;
            int k = rng.Next(n + 1);
            T value = list[k];
            list[k] = list[n];
            list[n] = value;
        }
    }
}
