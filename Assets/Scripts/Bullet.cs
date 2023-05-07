using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float speed = 10.0f;
    private Vector3 direction;
    public Vector3 Direction { set => direction = value; }
    
    private void Start()
    {
        Destroy(gameObject, 1.4f);
    }

    private void FixedUpdate()
    {
        var position = transform.position;
        transform.position = Vector3.MoveTowards(position, position + direction, 
            speed * Time.deltaTime);
    }
}
