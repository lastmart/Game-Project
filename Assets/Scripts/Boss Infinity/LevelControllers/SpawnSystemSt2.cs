using UnityEngine;

public class SpawnSystemSt2 : SpawnSystem
{
    protected override Enemies SelectEnemy(int spawnerNumber)
    {
        return spawnerNumber < 6 ? (Enemies)Random.Range(0, 2) : Enemies.Psi;
    }
}
