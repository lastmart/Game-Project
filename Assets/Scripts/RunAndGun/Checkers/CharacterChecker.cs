using UnityEngine;

public class CharacterChecker : MonoBehaviour
{
    protected Transform character;
    protected Vector3 enemyPosition;
    protected StaticEnemy enemy;

    private void Start()
    {
        enemy = gameObject.GetComponent<StaticEnemy>() ?? 
                gameObject.GetComponentInChildren<StaticEnemy>();
        character = enemy.characterPos.transform;
        enemyPosition = transform.position;
    }
}
