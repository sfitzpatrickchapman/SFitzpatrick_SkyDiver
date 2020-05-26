using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameSpeed : MonoBehaviour
{
    private float modifiedScale = 2.15f;

    void Start()
    {
       Time.timeScale = modifiedScale;
    }
}