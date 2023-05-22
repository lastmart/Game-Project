using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float speed = 10.0f;
    [SerializeField] private int damage = 1;
    
    private Vector3 direction;
    
    public Vector3 Direction { set => direction = value; }
    
    private void Start()
    {
        Destroy(gameObject, 3f);
    }

    private void FixedUpdate()
    {
        var position = transform.position;
        transform.position = Vector3.MoveTowards(position, position + direction, 
            speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        var unit = col.GetComponent<Character>();
        if (unit is null) return;
        unit.ReceiveDamage(damage);
    }
}
