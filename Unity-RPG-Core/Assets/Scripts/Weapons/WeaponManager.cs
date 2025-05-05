using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    public static WeaponManager Instance { get; private set; }

    public List<Weapon> weapons = new List<Weapon>();
    private int currentWeaponIndex = 0;

    public delegate void OnWeaponChanged(Weapon newWeapon);
    public event OnWeaponChanged WeaponChangedEvent;

    private void Awake()
    {
        if (Instance != null && Instance != this)
            Destroy(gameObject);
        else
            Instance = this;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(1))
            SwitchWeapon();

        if (Input.GetMouseButtonDown(0))
            weapons[currentWeaponIndex]?.Attack();
    }

    private void SwitchWeapon()
    {
        currentWeaponIndex = (currentWeaponIndex + 1) % weapons.Count;
        WeaponChangedEvent?.Invoke(weapons[currentWeaponIndex]);
    }
}