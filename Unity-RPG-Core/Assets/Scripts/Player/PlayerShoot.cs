using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    private void Awake()
    {
        PlayerInputHandler.Instance.OnFire += () => WeaponManager.Instance.Fire();
        PlayerInputHandler.Instance.OnSwitchWeapon += () => WeaponManager.Instance.SwitchWeapon();
    }
}