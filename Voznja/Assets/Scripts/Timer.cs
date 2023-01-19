using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    private float startTime;

    private void Start()
    {
        startTime = Time.time;
    }

    private void Update()
    {
        PlayerPrefs.SetFloat("timer", Time.time - startTime);
    }
}
