using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Sigma : Unit
{
    [SerializeField] private int maxShots = 5;
    [SerializeField] private float speed = 1.0f;
    
    public Transform firePoint;
    protected Animator Animator;
    protected Bullet Bullet;

    protected int ShotsNumber;
    protected Vector3 InitialPosition;
    protected Vector3 TargetPosition;

    private void Awake()
    {
        Damage = 1;
        InitialPosition = TargetPosition = transform.position;
        Bullet = Resources.Load<Bullet>("BossInfinity/Enemies/Auxiliaries/Bullet");
        Animator = GetComponent<Animator>();
    }
    
    public virtual void Shoot()
    {
        ShotsNumber += 1;
        if (ShotsNumber >= maxShots) Animator.SetBool("FinishAttack", true);
        var pointRight = firePoint.right;
        var obj = Instantiate(Bullet, firePoint.position, firePoint.rotation);
        obj.Direction = pointRight;
    }

    public void MoveToTarget() 
    {
        if (transform.position == TargetPosition) Animator.SetBool("StartAttack", true);
        MoveTo(TargetPosition);
    }

    public void MoveToInitialPoint()
    {
        if (transform.position == InitialPosition) Destroy(gameObject);
        MoveTo(InitialPosition);
    }

    public void SetTarget(Vector3 target) => TargetPosition = target;

    private void MoveTo(Vector3 target)
    {
        var position = transform.position;
        transform.position = Vector3.MoveTowards(position, target, speed * Time.deltaTime);
    }
}

