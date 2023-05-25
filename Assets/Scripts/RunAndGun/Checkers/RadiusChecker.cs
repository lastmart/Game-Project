using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadiusChecker : CharacterChecker
{
    [SerializeField] private int checkRadius;
    
    private void FixedUpdate()
    {
        Enemy.enabled = (Character.position - EnemyPosition).magnitude < checkRadius; 
    }
}
