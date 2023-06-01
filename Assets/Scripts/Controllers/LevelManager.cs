using System.Collections;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] protected Character character; 
    [SerializeField] protected GameObject gameOverWindow;
    [SerializeField] protected GameObject winWindow; 
    
    public virtual void ShowGameOverWindow()
    {
        character.enabled = false;
        StartCoroutine(WaitAndShowWindow(3, gameOverWindow));
    }
    
    protected virtual void ShowWinWindow()
    {
        character.enabled = false;
        StartCoroutine(WaitAndShowWindow(3, winWindow));
    }

    private IEnumerator WaitAndShowWindow(int seconds, GameObject window)
    {
        yield return new WaitForSecondsRealtime(seconds);
        window.SetActive(true);
    }
}
