using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{
    public bool levelFinished;
    public int timeLimit = 60;
    private int oneSecond = 0;
    public TextMeshProUGUI timer;
   
    void Start ()
    {
        levelFinished = false;
        oneSecond = 120;
        timer.text = "" + timeLimit;
    }
   
    // Update is called once per frame
    void Update ()
    {
        if (!levelFinished)
        {
            oneSecond--;
        }
 
        if (oneSecond <= 0)
        {
            Countdown();
            oneSecond = 120;
        }
    }
   
    //Count down once per second
    void Countdown()
    {
        timeLimit--;
        timer.text = "" + timeLimit;

        if (timeLimit <= 0)
        {
            levelFinished = true;
        }
    }
}

