using UnityEngine;

public class SpawnerUnderGround : Spawner
{
    public Transform characterPosition;
    
    protected override void SpawnPsi()
    {
        currentCapacity--;
        var spawnPosition = new Vector3(characterPosition.position.x, trf.position.y);
        var psiObj = Instantiate(psi, spawnPosition, Quaternion.identity);
        var psiComponent = psiObj.GetComponent<Psi>();
        psiComponent.SetTarget(spawnPosition + trf.right * 3);
        psiComponent.direction = trf.up;
    }

    protected override void SpawnSigma()
    {
        
    }

    protected override void SpawnIntegral()
    {
        currentCapacity--;
        var position = trf.position;
        Instantiate(integral, position, trf.rotation);
    }
}
