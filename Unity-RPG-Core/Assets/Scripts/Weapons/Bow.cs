using UnityEngine;

public class Bow : Weapon
{
    public int ammo = 10;

    public override void Attack()
    {
        if (ammo > 0)
        {
            Debug.Log("Выстрел из лука!");
            ammo--;
        }
        else
        {
            Debug.Log("Нет стрел!");
        }
    }
}