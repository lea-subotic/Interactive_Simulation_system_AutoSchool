using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
    private Timer timer;
    private void Start()
    {
        timer = FindObjectOfType<Timer>();
    }

    private void OnTriggerEnter(Collider other)
    {
        timer.StartCoroutine(Pass());
    }
    
    IEnumerator Pass()
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("PassMenu");
    }
}
