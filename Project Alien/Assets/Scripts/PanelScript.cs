using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PanelScript : MonoBehaviour
{
    [SerializeField]
    private GameObject _pauseButton;
    [SerializeField]
    private GameObject _resumeButton;
    [SerializeField]
    private GameObject _pauseMenu;
    [SerializeField]
    private GameObject _resumeMenu;
    [SerializeField]
    private GameObject _homeButton;
    [SerializeField]
    private GameObject _pausedText;
    void Start()
    {
        _pauseButton.SetActive(true);
        _resumeButton.SetActive(false);
        _homeButton.SetActive(false);
        _pausedText.SetActive(false);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P))
        {
            if (Time.timeScale == 0)
            {
                OnResume();
            }
            else
            {
                OnPause();
            }
        }
    }

    public void OnPause()
    {
        Time.timeScale = 0f;
        _pauseMenu.SetActive(true);
        _pauseButton.SetActive(false);
        _resumeButton.SetActive(true);
        _homeButton.SetActive(true);
        _pausedText.SetActive(true);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

       
    }

    public void OnResume()
    {
        Time.timeScale = 1.0f;
        _pauseButton.SetActive(true);
        _resumeButton.SetActive(false);
        _resumeMenu.SetActive(false);
        _homeButton.SetActive(false);
        _pausedText.SetActive(false);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void OnQuit()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("MainMenuScene");
    }
}
