using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 2.15f; // resets game speed
        GameIsPaused = false;
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f; // freeze game
        GameIsPaused = true;
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void QuitGame()
    {
        UnityEditor.EditorApplication.isPlaying = false;
        // Application.Quit(); <-- for actual build
    }
}
