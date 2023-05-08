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
            var enemy = (Enemies)generator.Next(0, 3);
            var spawnerNumber = generator.Next(0, spawners.Length - 1);
            spawners[spawnerNumber].SpawnEnemy(enemy);
            timeBetweenSpawn = startTimeBetweenSpawn;
        }
        else
        {
            timeBetweenSpawn -= Time.deltaTime;
        }
    }
}
