using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnSystem: MonoBehaviour
{
    [SerializeField] public bool isActive; 
    [SerializeField] private float startTimeBetweenSpawn = 2.0f;
    
    private Spawner[] spawners;
    private float timeBetweenSpawn;
    
    private void Awake()
    {
        spawners = gameObject.GetComponentsInChildren<Spawner>();
    }

    private void Update()
    {
        if(!isActive) return;
        
        if (timeBetweenSpawn <= 0)
        {
            var spawnerNumber = (int)(Random.value * 10) % (spawners.Length - 1);
            while (spawners[spawnerNumber].currentCapacity <= 0) 
                spawnerNumber = (int)(Random.value * 10) % (spawners.Length - 1);
            var enemy = SelectEnemy(spawnerNumber);
            spawners[spawnerNumber].SpawnEnemy(enemy);
            timeBetweenSpawn = startTimeBetweenSpawn;
        }
        else
        {
            timeBetweenSpawn -= Time.deltaTime;
        }
    }

    protected virtual Enemies SelectEnemy(int spawnerNumber)
    {
        while (true)
        {
            var nextEnemy = (Enemies)Random.Range(0, 3);
            if (nextEnemy is Enemies.Psi && spawnerNumber < 6 ||
                nextEnemy is Enemies.Sigma && spawnerNumber >= 6) 
                continue; 
            return nextEnemy;
        }
    }
}

public enum Enemies
{
    Integral,
    Sigma,
    Psi
}
