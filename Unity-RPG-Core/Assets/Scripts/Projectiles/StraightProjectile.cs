using UnityEngine;

public class StraightProjectile : Projectile
{
    protected override void Move()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
}