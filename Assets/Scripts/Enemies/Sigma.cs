using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sigma : Unit
{
    [SerializeField] private float fireRate = 2.0f;
    private Transform transform;

    private void Start()
    {
        transform = GetComponent<Transform>();
    }

    private void Shoot()
    {
        var position = transform.position;
        position.y += 0.3f;
    }
}
