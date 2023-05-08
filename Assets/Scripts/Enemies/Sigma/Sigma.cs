using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Sigma : Unit
{
    [SerializeField] private float fireRate = 1.0f;
    [SerializeField] private int maxShots = 5;
    [SerializeField] private float speed = 1.0f;
    
    public Transform firePoint;
    private Animator animator;
    private Bullet bullet;
    
    private int shotsNumber;
    private Vector3 initialPosition;
    private Vector3 targetPosition;

    private void Awake()
    {
        initialPosition = targetPosition = transform.position;
        bullet = Resources.Load<Bullet>("Bullet");
        animator = GetComponent<Animator>();
    }
    
    // InvokeRepeating(nameof(Shoot), fireRate, fireRate);
    
    private void Update()
    {
        
    }

    public void Shoot()
    {
        if (shotsNumber > maxShots) animator.SetBool("FinishAttack", true);
        var pointRight = firePoint.right;
        var obj = Instantiate(bullet, firePoint.position, firePoint.rotation);
        obj.Direction = pointRight;
    }

    public void MoveToTarget() => MoveTo(targetPosition);

    public void MoveToInitialPoint() => MoveTo(initialPosition);

    private void MoveTo(Vector3 target)
    {
        var position = transform.position;
        transform.position = Vector3.MoveTowards(position, targetPosition, speed * Time.deltaTime);
    }
    
    private enum SigmaStates
    {
        Move,
        Shoot
    }
}

