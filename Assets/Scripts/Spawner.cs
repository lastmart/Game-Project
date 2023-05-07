using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Spawner : MonoBehaviour
{
    [SerializeField] private bool active;
    [SerializeField] private float startTimeBetweenSpawn = 20.0f;
    public Integral integral;
    public Psi psi;
    public Sigma sigma;
    private float timeBetweenSpawn;
    
    private void Update()
    {
        if (!active) return;
        if (timeBetweenSpawn <= 0)
        {
            //Instantiate(integral, transform.position, Quaternion.identity);
            var position = transform.position;
            Instantiate(sigma, position, Quaternion.identity);
            sigma.MoveTo(new Vector3(-9, -3));
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