using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class LevelManager : MonoBehaviour
{
    public Character character; 
    public GameObject gameOverWindow;
    
    public virtual void ShowGameOverWindow()
    {
        gameOverWindow.SetActive(true);
    }
}
