using UnityEngine;

public class Bow : MonoBehaviour, IWeapon
{
    [SerializeField] private int ammo = 5;

    public void Attack()
    {
        if (ammo > 0)
        {
            Debug.Log("Bow shot!");
            ammo--;
        }
        else
        {
            Debug.Log("No ammo!");
        }
    }
}