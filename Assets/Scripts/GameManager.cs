using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    // Singelton
    public static GameManager instance;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }

        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    //public Job job; // Make this assigned via method in the future, once the "select job" functionality is built

    public bool isLost = false;
    public bool isWon = false;

    public List<Job> allJobs;
    
    public int competencyScore = 0;
    public int personalityScore = 0;

    public int competencyLoseThreshold = -100;
    public int personalityLoseThreshold = -100;
    public int combinedLoseThreshold = -100;

    public int competencyWinThreshold = 100;
    public int personalityWinThreshold = 100;
    public int combinedWinThreshold = 100;

    private void Update()
    {
        if (isLost)
        {
            isLost = false;
            GameOver();
            Debug.Log("Lost!");
        }

        if (isWon)
        {
            isWon = false;
            GameWon();
            Debug.Log("Won!");
        }
    }

    private void SelectJob()
    {

    }

    public IEnumerator EndRun() // read about IEnumerator
    {
        yield return new WaitForSeconds(2);
        if (competencyScore + personalityScore >= combinedWinThreshold)
        {
            GameWon();
        }
        else
        {
            GameOver();
        }
    }

    private void GameOver()
    {
        SceneManager.LoadScene("LossScene");
    }

    private void GameWon()
    {
        SceneManager.LoadScene("WinScene");
    }

    public void LoseCondition()
    {
        if (competencyScore <= competencyLoseThreshold | personalityScore <= personalityLoseThreshold | competencyScore + personalityScore <= combinedLoseThreshold)
        {
            isLost = true;
        }
        else
        {
            isLost = false;
        }
    }

    public void WinCondition()
    {
        if (competencyScore >= competencyWinThreshold | personalityScore >= personalityWinThreshold | competencyScore + personalityScore >= combinedWinThreshold)
        {
            isWon = true;
        }
        else
        {
            isWon = false;
        }
    }
}
