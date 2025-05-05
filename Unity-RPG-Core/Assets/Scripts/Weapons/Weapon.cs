using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    public string weaponName;
    public float damage;
    public float range;

    public abstract void Attack();
}