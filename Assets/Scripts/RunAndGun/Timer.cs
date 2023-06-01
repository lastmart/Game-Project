using System.Collections;
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
        delta = 1;
        StartCoroutine(TimeFlow());
    }

    private IEnumerator TimeFlow()
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
        // ReSharper disable once IteratorNeverReturns
    }
    
    public void StopTimer() => delta = 0;
}
