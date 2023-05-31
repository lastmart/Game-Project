using UnityEngine;

public class HorizontalChecker : CharacterChecker
{
    [SerializeField] private float horizontalDiff;
    
    private void FixedUpdate()
    {
        var characterPosition = character.position;
        enemy.enabled = Mathf.Abs(characterPosition.x - enemyPosition.x) < horizontalDiff
                        && enemyPosition.y >= characterPosition.y;
        if(enemy.enabled) enabled = false;
    }
}
