using UnityEngine;

public class SigmaV2 : Sigma
{
    private Vector3[] bulletDirections;

    private void Awake()
    {
        Damage = 1;
        maxShots = 3;
        initialPosition = targetPosition = transform.position;
        bullet = Resources.Load<Bullet>("BossInfinity/Enemies/Auxiliaries/BulletSt2");
        animator = GetComponent<Animator>();
        var up = firePoint.up;
        var right = firePoint.right;
        bulletDirections = new[] { right, (right * 3 + up).normalized, (right * 3 + up * -1).normalized };
    }
    
    public override void Shoot()
    {
        audioManager.Play("Shot");
        shotsNumber += 1;
        if (shotsNumber >= maxShots) animator.SetBool("FinishAttack", true);
        var position = firePoint.position;
        var rotation = firePoint.rotation;
        foreach (var direction in bulletDirections)
        {
            var bulletObj = Instantiate(bullet, position, rotation);
            bulletObj.Direction = direction;
        }
    }
}
