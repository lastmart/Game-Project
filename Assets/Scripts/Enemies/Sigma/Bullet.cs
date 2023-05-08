using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float speed = 10.0f;
    private Vector3 direction;
    public Vector3 Direction { set => direction = value; }
    public float Speed { set => speed = value; }

    private void Start()
    {
        Destroy(gameObject, 2.1f);
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
        unit.ReceiveDamage(1);
    }
}
