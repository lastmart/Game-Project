using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Sigma : Enemy
{
    [SerializeField] protected AudioManager audioManager;
    [SerializeField] protected int maxShots = 5;
    [SerializeField] private float speed = 1.0f;
    
    public Transform firePoint;
    protected Animator animator;
    protected Bullet bullet;

    protected int shotsNumber;
    protected Vector3 initialPosition;
    protected Vector3 targetPosition;

    private void Awake()
    {
        Damage = 1;
        initialPosition = targetPosition = transform.position;
        bullet = Resources.Load<Bullet>("BossInfinity/Enemies/Auxiliaries/Bullet");
        animator = GetComponent<Animator>();
    }
    
    public virtual void Shoot()
    {
        audioManager.Play("Shot");
        shotsNumber += 1;
        if (shotsNumber >= maxShots) animator.SetBool("FinishAttack", true);
        var pointRight = firePoint.right;
        var obj = Instantiate(bullet, firePoint.position, firePoint.rotation);
        obj.Direction = pointRight;
    }

    public void MoveToTarget() 
    {
        if (transform.position == targetPosition) animator.SetBool("StartAttack", true);
        MoveTo(targetPosition);
    }

    public void MoveToInitialPoint()
    {
        if (transform.position == initialPosition) Destroy(gameObject);
        MoveTo(initialPosition);
    }

    public void SetTarget(Vector3 target) => targetPosition = target;

    private void MoveTo(Vector3 target)
    {
        var position = transform.position;
        transform.position = Vector3.MoveTowards(position, target, speed * Time.deltaTime);
    }
}

