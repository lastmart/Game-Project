using System.Collections;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public Character character; 
    public GameObject gameOverWindow;
    
    public virtual void ShowGameOverWindow()
    {
        character.enabled = false;
        StartCoroutine(WaitAndShow(3));
    }

    private IEnumerator WaitAndShow(int seconds)
    {
        yield return new WaitForSecondsRealtime(seconds);
        gameOverWindow.SetActive(true);
    }
}
