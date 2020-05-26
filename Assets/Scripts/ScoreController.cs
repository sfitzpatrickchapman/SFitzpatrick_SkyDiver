using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour
{
    public Text scoreText;
    public Text highscoreText;
    public float score = 0f;
    private float pointIncreasedPerSecond;
    // highscores stored in the PlayerPrefs key: scoreStorage

    void Start()
    {
        pointIncreasedPerSecond = 2f;
        highscoreText.text = "HIGHSCORE: " + PlayerPrefs.GetInt("scoreStorage"); // displays highscore
    }
    
    void Update() // increases score every second
    {
        highscoreText.text = "HIGHSCORE: " + PlayerPrefs.GetInt("scoreStorage");
        score += pointIncreasedPerSecond * Time.deltaTime; // adds to score every second
        scoreText.text = "SCORE: " + (int)score;

        if (PlayerPrefs.GetInt("scoreStorage") <= score) // if current score > highscore
        {
            PlayerPrefs.SetInt("scoreStorage", (int)score); // set new highscore
        }
    }

    public void UpdateScore() { // updates score when incremented and called from balloonManager
        scoreText.GetComponent<Text>().text = "Score: " + (int)score;
    }
}
