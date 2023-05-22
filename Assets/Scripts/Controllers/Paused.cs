using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Paused : MonoBehaviour
{
    [SerializeField] private GameObject pause;

    void Start()
    {
        pause.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pause.SetActive(true);
            Time.timeScale = 0;
        }
    }

    public void PauseOff()
    {
        pause.SetActive(false);
        Time.timeScale = 1;
    }
    
    public void Menu()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1;
    }
    
    public void Settings()
    {
        SceneManager.LoadScene(2);
        Time.timeScale = 1;
    }
}
