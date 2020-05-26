using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MenuHighscore : MonoBehaviour
{
    public TextMeshProUGUI highscore;

    void Start()
    {
        highscore = GetComponent<TextMeshProUGUI>();
        Debug.Log("Start works ");
        highscore.text = "HIGHSCORE: " + PlayerPrefs.GetInt("scoreStorage");
        // displays highscore
    }
}
