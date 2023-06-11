using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuUi : MonoBehaviour
{
    public GameObject InstructionsPanel;

    public GameObject MenuPanel;

    public void LoadGame()
    {
        SceneManager.LoadScene("TestSceneAaron");
    }

    public void ShowInstructions()
    {
        MenuPanel.SetActive(false);
        InstructionsPanel.SetActive(true);
    }

    public void HideInstructions()
    {
        InstructionsPanel.SetActive(false);
        MenuPanel.SetActive(true);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
