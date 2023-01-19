using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashFail : MonoBehaviour
{
    private Timer timer;

    private void Start()
    {
        timer = FindObjectOfType<Timer>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        timer.StopAllCoroutines();
        StartCoroutine(Fail());
    }

    IEnumerator Fail()
    {
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene("FailMenu");
    }
}
