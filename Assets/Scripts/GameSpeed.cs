using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameSpeed : MonoBehaviour
{
    public float modifiedScale;

    void Start()
    {
       Time.timeScale = modifiedScale;
    }
}
