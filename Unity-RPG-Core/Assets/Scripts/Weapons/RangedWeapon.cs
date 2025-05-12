using UnityEngine;

public class RangedWeapon : WeaponBase
{
    [SerializeField] private string projectileTag = "Arrow";
    [SerializeField] private Transform firePoint;

    public override void Attack()
    {
        ProjectilePool.Instance.Spawn(projectileTag, firePoint.position, firePoint.rotation);
        Debug.Log($"{name}: Fire projectile {projectileTag}");
    }
}