using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunAndGunLevelController : LevelManager
{
    public Timer timer;
    
    public override void ShowGameOverWindow()
    {
        base.ShowGameOverWindow();
        timer.StopTimer();
    }
}
