using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class BossInfinityLevelController : MonoBehaviour
{
    public SpawnSystem firstStage;
    public SpawnSystem secondStage;
    public BossInfinity boss;
    
    public void SetFirstStage()
    {
        firstStage.isActive = true;
        secondStage.isActive = false;
    }

    public void SetSecondStage()
    {
        firstStage.isActive = false;
        secondStage.isActive = true;
    }

    public void DisableAll() => firstStage.isActive = secondStage.isActive = false;
}
