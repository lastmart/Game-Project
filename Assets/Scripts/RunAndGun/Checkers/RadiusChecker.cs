using UnityEngine;

public class RadiusChecker : CharacterChecker
{
    [SerializeField] private int checkRadius;
    
    private void FixedUpdate()
    {
        enemy.enabled = (character.position - enemyPosition).magnitude < checkRadius; 
    }
}
