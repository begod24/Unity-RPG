using UnityEngine;

public class Bow : MonoBehaviour, IWeapon
{
    [SerializeField] private GameObject arrowPrefab;
    [SerializeField] private Transform firePoint;
    [SerializeField] private int ammo = 5;

    public void Attack()
    {
        if (ammo <= 0)
        {
            Debug.Log("Out of ammo!");
            return;
        }

        GameObject arrow = Instantiate(arrowPrefab, firePoint.position, firePoint.rotation);
        arrow.SetActive(true);

        Debug.Log("Shot an arrow!");
        ammo--;
    }
}