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
        Enemy.enabled = Mathf.Abs(Character.position.x - EnemyPosition.x) < horizontalDiff;
        if(Enemy.enabled) enabled = false;
    }
}
