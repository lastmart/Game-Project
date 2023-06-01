using UnityEngine;

public class BossInfinityLevelController : LevelManager
{
    [SerializeField] private SpawnSystem firstStage;
    [SerializeField] private SpawnSystem secondStage;
    [SerializeField] private BossInfinityStages stage;

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
                    ShowWinWindow();
                    break;
            }
        }
    }

    private void SetFirstStage()
    {
        firstStage.enabled = true;
        secondStage.enabled = false;
    }

    private void SetSecondStage()
    {
        firstStage.enabled = false;
        secondStage.enabled = true;
    }

    private void DisableAllSpawners() => firstStage.enabled = secondStage.enabled = false;

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
