using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mushroom : Unit
{
    [SerializeField] private float startTimeBetweenSpawn = 1.0f;
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
}
