using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using Controllers;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.SceneManagement;

public class RunAndGunLevelController : LevelManager
{
    public Timer timer;
    public PostProcessVolume lights;
    public CinemachineVirtualCamera cmn;
    
    public override void ShowGameOverWindow()
    {
        lights.enabled = false;
        cmn.m_Follow = cmn.transform;
        base.ShowGameOverWindow();
        timer.StopTimer();
        Destroy(character);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player")) SceneManager.LoadScene(0);
    }
}
