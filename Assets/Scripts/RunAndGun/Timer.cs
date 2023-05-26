using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    private int sec;
    private int min;
    private int delta;
    public Text timerText;

    private void Start()
    {
        delta = 0;
    }

    IEnumerator TimeFlow()
    {
        while (true)
        {
            if (sec == 59)
            {
                min++;
                sec = -1;
            }

            sec += delta;
            timerText.text = $"{min:D2} : {sec:D2}";
            yield return new WaitForSeconds(1);
        }
    }

    public void StartStop(int delta)
    {
        this.delta = delta;
    }
    
}
