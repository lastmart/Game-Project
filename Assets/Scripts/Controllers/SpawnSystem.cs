using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnSystem: MonoBehaviour
{
    [SerializeField] public bool isActive; 
    [SerializeField] private float startTimeBetweenSpawn = 4.0f;
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

    private Enemies SelectEnemy(int spawnerNumber)
    {
        if (spawnerNumber < 6)
            return (Enemies)(Random.value * 10 % 2);
        return Enemies.Psi;
    }
}
