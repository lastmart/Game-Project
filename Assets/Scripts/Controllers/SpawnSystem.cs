using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Random = System.Random;

public class SpawnSystem : MonoBehaviour
{
    [SerializeField] private bool isActive; 
    [SerializeField] private float startTimeBetweenSpawn = 5.0f;
    private Spawner[] spawners;
    private Random generator;
    private float timeBetweenSpawn;

    
    private void Awake()
    {
        spawners = gameObject.GetComponentsInChildren<Spawner>();
        generator = new Random(DateTime.Now.Millisecond);
    }

    private void Update()
    {
        if(!isActive) return;
        
        if (timeBetweenSpawn <= 0)
        {
            var spawnerNumber = generator.Next(0, spawners.Length - 1);
            var enemy = SelectEnemy(spawnerNumber);
            spawners[spawnerNumber].SpawnEnemy(enemy);
            timeBetweenSpawn = startTimeBetweenSpawn;
        }
        else
        {
            timeBetweenSpawn -= Time.deltaTime;
        }
    }

    private Enemies SelectEnemy(int spawnerNumber)
    {
        if (spawnerNumber < 6)
            return (Enemies)generator.Next(0, 2);
        return Enemies.Psi;
    }
}
