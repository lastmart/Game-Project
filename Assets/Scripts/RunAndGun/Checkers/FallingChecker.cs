using UnityEngine;

public class FallingChecker : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D col)
    {
        var character = col.GetComponent<Character>();
        if (character is null) return;
        character.ReceiveDamage(3);
    }
}
