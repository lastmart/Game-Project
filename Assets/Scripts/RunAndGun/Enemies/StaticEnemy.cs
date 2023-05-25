using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class StaticEnemy : Unit
{ 
    [SerializeField] private int lives = 3;
    public Transform character;
    
    public override void ReceiveDamage(int damage)
    {
        lives -= damage;
        if (lives <= 0) Die();
    }
}
