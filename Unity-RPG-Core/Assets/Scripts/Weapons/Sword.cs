using UnityEngine;

public class Sword : MonoBehaviour, IWeapon
{
    [SerializeField] private float damage = 10f;

    public void Attack()
    {
        Debug.Log("Sword attack! Damage: " + damage);
    }
}