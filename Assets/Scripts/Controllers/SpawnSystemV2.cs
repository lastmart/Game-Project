using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnSystemV2 : MonoBehaviour
{
    [SerializeField] private bool isActive; 
    [SerializeField] private float startTimeBetweenSpawn = 4.0f;
    private SpawnerV2[] spawners;
    private float timeBetweenSpawn;
    
    private void Awake()
    {
        spawners = gameObject.GetComponentsInChildren<SpawnerV2>();
    }

    private void Update()
    {
        if(!isActive) return;
        
        if (timeBetweenSpawn <= 0)
        {
            var spawnerNumber = (int)(Random.value * 10) % (spawners.Length - 1);
            for (var i = 0 ; i < 2 ; i++)
            {
                while (spawners[spawnerNumber].currentCapacity <= 0)
                    spawnerNumber = (int)(Random.value * 10) % (spawners.Length - 1);
                var enemy = SelectEnemy();
                spawners[spawnerNumber].SpawnEnemy(enemy);
            }
            timeBetweenSpawn = startTimeBetweenSpawn;
        }
        else
        {
            timeBetweenSpawn -= Time.deltaTime;
        }
    }

    private Enemies SelectEnemy()
    {
        return (Enemies)(Random.value * 10 % 2);
    }
}
