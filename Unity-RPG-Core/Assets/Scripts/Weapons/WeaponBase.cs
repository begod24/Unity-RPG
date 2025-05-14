using UnityEngine;

public abstract class WeaponBase : MonoBehaviour, IWeapon
{
    public abstract void Attack();
}