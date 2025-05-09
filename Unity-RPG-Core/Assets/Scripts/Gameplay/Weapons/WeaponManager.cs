using UnityEngine;
using System;

public class WeaponManager : SingletonBehaviour<WeaponManager>
{
    [SerializeField] private GameObject[] weapons;
    private int current = 0;
    public event Action<IWeapon> OnWeaponChanged;
    private IWeapon weapon;

    private void Start()
    {
        Equip(0);
    }

    public void SwitchWeapon()
    {
        Equip((current + 1) % weapons.Length);
    }

    public void Fire()
    {
        weapon?.Attack();
    }

    private void Equip(int index)
    {
        for(int i=0; i<weapons.Length; i++)
            weapons[i].SetActive(i==index);
        current = index;
        weapon = weapons[index].GetComponent<IWeapon>();
        OnWeaponChanged?.Invoke(weapon);
    }
}