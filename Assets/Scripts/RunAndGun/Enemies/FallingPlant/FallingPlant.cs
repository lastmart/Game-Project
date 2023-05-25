using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlant : StaticEnemy
{
    [SerializeField] private float speed = 8f;
    private Rigidbody2D rb;
    private Vector3 direction;
    private GameObject deathEffect;
    
    private void Start()
    {
        deathEffect = Resources.Load<GameObject>("RunAndGun/Effects/FallingPlantDestroy Variant");
        rb = GetComponent<Rigidbody2D>();
        direction = transform.up;
        Damage = 1;
    }
    
    private void FixedUpdate()
    {
        var position = transform.position;
        var newPosition = Vector2.MoveTowards(position, position + direction,
            speed * Time.deltaTime);
        rb.MovePosition(newPosition);
    }

    protected override void OnTriggerEnter2D(Collider2D col)
    {
        Attack(col);
        Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
    
    public override void ReceiveDamage(int damage)
    {
        
    }
}
