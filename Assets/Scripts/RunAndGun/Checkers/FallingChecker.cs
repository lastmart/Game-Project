using UnityEngine;

public class FallingChecker : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D col)
    {
        var character = col.GetComponent<Character>();
        if (character is null) return;
        character.transform.position = new Vector3(-4, -2);
        character.lives = character.maxLives;
        character.charLivesBar.Refresh();
    }
}
