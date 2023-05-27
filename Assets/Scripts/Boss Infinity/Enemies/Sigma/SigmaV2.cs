using UnityEngine;

public class SigmaV2 : Sigma
{
    [SerializeField] private int maxShots = 3;
    
    private Vector3[] bulletDirections;

    private void Awake()
    {
        Damage = 1;
        InitialPosition = TargetPosition = transform.position;
        Bullet = Resources.Load<Bullet>("BossInfinity/Enemies/Auxiliaries/BulletSt2");
        Animator = GetComponent<Animator>();
        var up = firePoint.up;
        var right = firePoint.right;
        bulletDirections = new[] { right, (right * 3 + up).normalized, (right * 3 + up * -1).normalized };
    }
    
    public override void Shoot()
    {
        ShotsNumber += 1;
        if (ShotsNumber >= maxShots) Animator.SetBool("FinishAttack", true);
        var position = firePoint.position;
        var rotation = firePoint.rotation;
        foreach (var direction in bulletDirections)
        {
            var obj = Instantiate(Bullet, position, rotation);
            obj.Direction = direction;
        }
    }
}
