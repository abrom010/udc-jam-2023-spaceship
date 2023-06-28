using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuUi : MonoBehaviour
{
    public GameObject InstructionsPanel;

    public GameObject MenuPanel;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
    }

    public void LoadGame()
    {
        SceneManager.LoadScene("IntroductionScene");
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
