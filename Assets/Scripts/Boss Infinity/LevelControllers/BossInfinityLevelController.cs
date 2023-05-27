using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class BossInfinityLevelController : LevelManager
{
    public SpawnSystem firstStage;
    public SpawnSystem secondStage;
    public BossInfinity boss;
    private BossInfinityStages stage;

    private void Start()
    {
        Stage = BossInfinityStages.Zero;
    }

    public BossInfinityStages Stage
    {
        get => stage;
        set
        {
            stage = value;
            switch (Stage)
            {
                case BossInfinityStages.First:
                    SetFirstStage();
                    break;
                case BossInfinityStages.Second:
                    SetSecondStage();
                    break;
                case BossInfinityStages.End:
                    DisableAllSpawners();
                    character.enabled = false;
                    break;
            }
        }
    }

    private void SetFirstStage()
    {
        firstStage.isActive = true;
        secondStage.isActive = false;
    }

    private void SetSecondStage()
    {
        firstStage.isActive = false;
        secondStage.isActive = true;
    }

    private void DisableAllSpawners() => firstStage.isActive = secondStage.isActive = false;

    public override void ShowGameOverWindow()
    {
        base.ShowGameOverWindow();
        DisableAllSpawners();
    }
}

public enum BossInfinityStages
{
    Zero,
    First,
    Second,
    End
}
