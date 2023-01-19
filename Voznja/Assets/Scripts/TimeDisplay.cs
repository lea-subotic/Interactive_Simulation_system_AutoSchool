using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimeDisplay : MonoBehaviour
{
    [SerializeField] TMP_Text text;
    void Start()
    {
        float seconds = PlayerPrefs.GetFloat("timer");

        int minutes = (int) seconds / 60;

        if (minutes == 0)
            text.text = $"Vrijeme: {seconds} sekundi";
        else
            text.text = $"Vrijeme: {minutes} minuta i {seconds % 60} sekundi";
    }
}
