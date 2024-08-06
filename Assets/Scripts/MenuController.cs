using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class MenuController : MonoBehaviour
{
    [SerializeField] private GameObject mainUI;
    [SerializeField] private GameObject settingsMenu;

    public void Update()
    {
        ToggleSettingsMenu();
        DeselectButton();
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("Interview"); // change to selection menu
    }

    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }

    public void ToggleSettingsMenu()
    {
        if (mainUI.activeSelf == true)
        {
            if (Input.GetKeyUp(KeyCode.Escape))
            {
                mainUI.SetActive(false);
                settingsMenu.SetActive(true);
            }
        }
        else if (settingsMenu.activeSelf == true)
        {
            if (Input.GetKeyUp(KeyCode.Escape))
            {
                mainUI.SetActive(true);
                settingsMenu.SetActive(false);
            }
        }
    }

    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void GoToJobSelection()
    {
        SceneManager.LoadScene("JobSelection");
    }

    public void GoToApplicantSelection()
    {
        SceneManager.LoadScene("ApplicantSelection");
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Interview");
    }

    public void DeselectButton()
    {
        EventSystem.current.SetSelectedGameObject(null);
    }
}
