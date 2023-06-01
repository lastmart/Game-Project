using UnityEngine;

public class Spawner : MonoBehaviour
{
    [Header("Physics parameters")]
    [SerializeField] private float reloadFrequency = 20.0f;
    [SerializeField] public int maxCapacity = 3;
    
    [Header("Enemies")]
    [SerializeField] protected GameObject integral;
    [SerializeField] protected GameObject psi;
    [SerializeField] private GameObject sigma;

    protected Transform trf;
    private float reloadTime; 
    public int currentCapacity;

    private void Awake()
    {
        trf = gameObject.GetComponent<Transform>();
        reloadTime = reloadFrequency;
        currentCapacity = maxCapacity;
    }

    private void FixedUpdate()
    {
        reloadTime -= 0.01f;
        if (reloadTime > 0) return;
        reloadTime = reloadFrequency;
        currentCapacity = maxCapacity;
    }

    // ReSharper disable Unity.PerformanceAnalysis
    public void SpawnEnemy(Enemies enemy)
    {
        switch (enemy) 
        {
            case Enemies.Sigma: SpawnSigma();
                break;
            case Enemies.Integral: SpawnIntegral();
                break;
            case Enemies.Psi: SpawnPsi();
                break;
        }
    }

    protected virtual void SpawnIntegral()
    {
        currentCapacity--;
        var position = trf.position;
        Instantiate(integral, position, trf.rotation);
    }

    protected virtual void SpawnSigma()
    {
        currentCapacity -= 3;
        var position = trf.position;
        var sigmaObj = Instantiate(sigma, position, trf.rotation);
        var sigmaComponent = sigmaObj.GetComponent<Sigma>();
        sigmaComponent.SetTarget(position + trf.right * 3);
    }

    protected virtual void SpawnPsi()
    {
        currentCapacity--;
        var position = trf.position;
        var psiObj = Instantiate(psi, position, trf.rotation);
        var psiComponent = psiObj.GetComponent<Psi>();
        psiComponent.SetTarget(position + trf.up * 4);
    }
    
    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, 0.5f);
    }
}
