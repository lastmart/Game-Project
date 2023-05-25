using System;
using UnityEngine;

public class CharacterChecker : MonoBehaviour
{
    private Vector3 enemyPosition;
    private Transform character;
    private StaticEnemy enemy;

    private void Awake()
    {
        enemy = gameObject.GetComponent<StaticEnemy>();
        character = enemy.character.transform;
        enemyPosition = enemy.transform.position;
    }

    private void FixedUpdate()
    {
        enemy.enabled = (character.position - enemyPosition).magnitude < 12; 
    }
}
