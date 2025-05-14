using UnityEngine;

public class MeleeWeapon : WeaponBase
{
    [SerializeField] private int damage = 10;
    public override void Attack()
    {
        Debug.Log($"{name}: Melee attack, damage {damage}");
    }
}