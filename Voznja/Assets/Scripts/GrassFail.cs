using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GrassFail : MonoBehaviour
{
    [SerializeField] private WheelCollider wheelCollider;
    private Timer timer;

    private void Start()
    {
        timer = FindObjectOfType<Timer>();
    }

    private void FixedUpdate()
    {
        if (wheelCollider.GetGroundHit(out WheelHit hit))
        {
            if (hit.collider.gameObject.CompareTag("Terrain"))
            {
                timer.StopAllCoroutines();
                StartCoroutine(Fail());
            }
        }
    }
    IEnumerator Fail()
    {
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene("FailMenu");
    }
}
