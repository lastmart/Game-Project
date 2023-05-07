using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Sigma : Unit
{
    [SerializeField] private float fireRate = 1.0f;
    public Transform firePoint;
    private Bullet bullet;

    private void Awake()
    {
        bullet = Resources.Load<Bullet>("Bullet");
    }

    private void Start()
    {
        InvokeRepeating(nameof(Shoot), fireRate, fireRate);
    }

    private void Shoot()
    {
        Instantiate(bullet, firePoint.position, firePoint.rotation);
    }

    public void MoveTo(Vector3 targetPosition)
    {
        var position = transform.position;
        transform.position = Vector3.MoveTowards(position, targetPosition, 
            (targetPosition-position).magnitude);
    }
}
