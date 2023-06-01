public class SpawnerSt2 : Spawner
{
    public bool psiIsSpawned; 
    
    protected override void SpawnPsi()
    {
        if (psiIsSpawned) return;
        currentCapacity--;
        var position = trf.position;
        var psiObj = Instantiate(psi, position, trf.rotation);
        var psiComponent = psiObj.GetComponent<StaticPsi>();
        psiComponent.SetTarget(position + trf.up * 3);
        psiComponent.direction = transform.up;
        psiComponent.spawner = this;
        psiIsSpawned = true;
    }
}
