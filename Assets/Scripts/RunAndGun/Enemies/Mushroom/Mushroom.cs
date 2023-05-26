using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mushroom : StaticEnemy
{
    [SerializeField] private float startTimeBetweenSpawn = 2f;
    private float timeBetweenSpawn;
    public GameObject spores;
    private Animator animator;
    
    private void Start()
    {
        animator = gameObject.GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        if (timeBetweenSpawn <= 0)
        {
            animator.SetTrigger("Attack");
            Instantiate(spores, transform.position, Quaternion.identity);
            timeBetweenSpawn = startTimeBetweenSpawn;
        }
        else
        {
            timeBetweenSpawn -= Time.deltaTime;
        }
    }
    
    protected override void Die()
    {
        Destroy(gameObject);
    }
}
