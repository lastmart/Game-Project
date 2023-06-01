using UnityEngine;

public class FallingChecker : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D col)
    {
        var character = col.GetComponent<Character>();
        // ReSharper disable once Unity.NoNullPropagation
        character?.ReceiveDamage(3);
    }
}
