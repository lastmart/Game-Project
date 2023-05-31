using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Unit
{
    protected virtual void OnTriggerEnter2D(Collider2D col) => Attack(col);

    protected virtual void OnTriggerStay2D(Collider2D other) => Attack(other);

    protected void Attack(Collider2D collider)
    {
        var character = collider.GetComponent<Character>();
        if (character is null) return;
        character.ReceiveDamage(Damage);
    }

}
