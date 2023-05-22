using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerUnderGround : Spawner
{
    public Transform characterPosition;
    
    protected override void SpawnPsi()
    {
        currentCapacity--;
        var transform1 = transform;
        var position = new Vector3(characterPosition.position.x, transform1.position.y);
        var obj = Instantiate(psi, position, Quaternion.identity);
        var psiObj = obj.GetComponent<Psi>();
        psiObj.SetTarget(position + transform1.right * 3);
        psiObj.direction = transform1.up;
    }

    protected override void SpawnSigma()
    {
        
    }

    protected override void SpawnIntegral()
    {
        currentCapacity--;
        var transform1 = transform;
        var position = transform1.position;
        Instantiate(integral, position, transform1.rotation);
    }
}
