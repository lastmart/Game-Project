using System;
using UnityEngine;

public class CharacterChecker : MonoBehaviour
{
    protected Vector3 EnemyPosition;
    protected Transform Character;
    protected StaticEnemy Enemy;

    private void Start()
    {
        Enemy = gameObject.GetComponent<StaticEnemy>() ?? 
                gameObject.GetComponentInChildren<StaticEnemy>();
        Character = Enemy.character.transform;
        EnemyPosition = transform.position;
    }
}
