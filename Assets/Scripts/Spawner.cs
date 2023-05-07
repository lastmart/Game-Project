using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

[RequireComponent(typeof(Integral))]
public class Spawner : MonoBehaviour
{
    [SerializeField] private bool active;
    [SerializeField] private float startTimeBetweenSpawn = 5.0f;
    public Integral integral = new (new Vector3(1,0));
    public GameObject psi;
    public GameObject sigma;
    private float timeBetweenSpawn;
    
    private void Update()
    {
        if (!active) return;
        if (timeBetweenSpawn <= 0)
        {
            Instantiate(integral, transform.position, Quaternion.identity);
            timeBetweenSpawn = startTimeBetweenSpawn;
        }
        else
        {
            timeBetweenSpawn -= Time.deltaTime;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, 0.5f);
    }
}