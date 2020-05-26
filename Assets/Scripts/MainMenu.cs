using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenu : MonoBehaviour
{
    public TextMeshProUGUI highscore;

    void Start()
    {
        // causing an error even though fully functional; don't know why
        if (highscore == null || highscore.text == null)
            highscore.text = "0";
        highscore.text = "HIGHSCORE: " + PlayerPrefs.GetInt("scoreStorage"); // displays highscore
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); // goes to next scene
    }

    public void QuitGame()
    {
        UnityEditor.EditorApplication.isPlaying = false; // only works in editor
        // Application.Quit();  <--- this would actually quit if built
    }

    public void ResetHighscore()
    {
        PlayerPrefs.SetInt("scoreStorage", 0);
        highscore.text = "HIGHSCORE: 0";
    }
}
