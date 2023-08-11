using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{
    public bool levelFinished;
    public TextMeshProUGUI timerText;
    public float timer;

    void Update()
    {
        timer -= Time.deltaTime;
        timerText.text = "" + timer.ToString("00");

        if (timer <= 0)
        {
            timer = 0;
            levelFinished = true;
        }
    }
}

