using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PausePanelScript : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject PausePanel;
    public GameObject Strikes;
    public GameObject CAMLOCText;
    public GameObject LEFTBTN;  
    public GameObject ConfirmationPanel;
    public GameObject QuitButton;
    public void Resume()
    {
        PausePanel.SetActive(false);
        Strikes.SetActive(true);
        CAMLOCText.SetActive(true);
        LEFTBTN.SetActive(true);
        Time.timeScale = 1f;
        GameIsPaused = false;
        AudioManager.Instance.musicSource.mute = false;
    }

    void Pause()
    {
        PausePanel.SetActive(true);
        Strikes.SetActive(false);
        CAMLOCText.SetActive(false);
        LEFTBTN.SetActive(false);
        Time.timeScale = 0f;
        GameIsPaused = true;
        AudioManager.Instance.musicSource.mute = true;
    }
    public void OpenConfirmExit()
    {
       ConfirmationPanel.SetActive(true);
       QuitButton.SetActive(false);
       AudioManager.Instance.PlaySFX("UIButton");
    }

    public void CloseConfirmExit()
    {
        ConfirmationPanel.SetActive(false);
        QuitButton.SetActive(true);
        AudioManager.Instance.PlaySFX("UIButton");
    }

    void Start()
    {

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P))
        {
            if (!GameIsPaused)
            {
                Pause();
            }
            else
            {
                Resume();
            }
        }
    }
}
