using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SharpBush : StaticEnemy
{
    [SerializeField] private int damage = 1;
    [SerializeField] private float verticalPower = 60.0f;
    [SerializeField] private float horizontalPower = 30.0f;
    private void OnCollisionEnter2D(Collision2D col) => Attack(col);

    private void OnCollisionStay2D(Collision2D collision) => Attack(collision);

    private void Attack(Collision2D collision)
    {
        var character = collision.gameObject.GetComponent<Character>();
        if (character is null) return;
        character.ReceiveDamage(damage);
        var rb = collision.rigidbody;
        rb.velocity = Vector2.zero;
        rb.AddForce(transform.up * verticalPower, ForceMode2D.Impulse);
        var repulsionDirection = character.isFacingRight ? transform.right : -transform.right;
        rb.AddForce( repulsionDirection * horizontalPower, ForceMode2D.Impulse);
    }
}
