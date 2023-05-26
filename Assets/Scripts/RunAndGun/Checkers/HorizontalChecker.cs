using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class HorizontalChecker : CharacterChecker
{
    [SerializeField] private float horizontalDiff;
    
    private void FixedUpdate()
    {
        var characterPosition = Character.position;
        Enemy.enabled = Mathf.Abs(characterPosition.x - EnemyPosition.x) < horizontalDiff
                        && EnemyPosition.y >= characterPosition.y;
        if(Enemy.enabled) enabled = false;
    }
}
