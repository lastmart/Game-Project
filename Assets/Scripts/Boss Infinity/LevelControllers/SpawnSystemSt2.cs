using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSystemSt2 : SpawnSystem
{
    protected override Enemies SelectEnemy(int spawnerNumber)
    {
        return spawnerNumber < 6 ? base.SelectEnemy(spawnerNumber) : Enemies.Psi;
    }
}
