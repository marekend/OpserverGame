using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject ConfirmationPanel;
    public GameObject QuitButton;
    public void PlayGame ()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        AudioManager.Instance.PlaySFX("UIButton");
    }

    public void QuitGame ()
    {
        AudioManager.Instance.PlaySFX("UIButton");
        Debug.Log("Game Quit");
        Application.Quit();

    }

    public void BackToMenu ()
    {
        AudioManager.Instance.PlaySFX("UIButton");
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(0);
        
    }

    public void OpenConfirmExit()
    {
        ConfirmationPanel.SetActive(true);
        QuitButton.SetActive(false);
    }

    public void CloseConfirmExit()
    {
        ConfirmationPanel.SetActive(false);
        QuitButton.SetActive(true);
    }

}
