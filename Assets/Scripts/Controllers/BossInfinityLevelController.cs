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

    private void Start()
    {
        firstStage.isActive = true;
    }

    private void FixedUpdate()
    {
        if (!boss.inRange) return;
        if (boss.lives <= 0)
        {
            secondStage.isActive = firstStage.isActive = false;
        }
        else
        {
            secondStage.isActive = true;
            firstStage.isActive = false;
        }

    }
}
