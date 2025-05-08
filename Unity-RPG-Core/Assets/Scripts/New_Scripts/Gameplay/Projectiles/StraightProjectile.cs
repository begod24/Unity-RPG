using UnityEngine;

public class StraightProjectile : ProjectileBase
{
    protected override void Move() => transform.Translate(Vector3.forward * speed * Time.deltaTime);
}