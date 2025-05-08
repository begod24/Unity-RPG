using UnityEngine;
using UnityEngine.InputSystem;

public class WeaponManager : MonoBehaviour
{
    [SerializeField] private GameObject[] weaponObjects;

    private IWeapon currentWeapon;
    private int currentIndex = 0;

    private PlayerInputActions inputActions;

    private void Awake()
    {
        inputActions = new PlayerInputActions();

        inputActions.Gameplay.Fire.performed += _ => currentWeapon?.Attack();
        inputActions.Gameplay.SwitchWeapon.performed += _ => SwitchWeapon();
    }

    private void OnEnable()
    {
        inputActions.Enable();
    }

    private void OnDisable()
    {
        inputActions.Disable();
    }

    private void Start()
    {
        EquipWeapon(0);
    }

    private void SwitchWeapon()
    {
        currentIndex = (currentIndex + 1) % weaponObjects.Length;
        EquipWeapon(currentIndex);
    }

    private void EquipWeapon(int index)
    {
        for (int i = 0; i < weaponObjects.Length; i++)
            weaponObjects[i].SetActive(i == index);

        currentWeapon = weaponObjects[index].GetComponent<IWeapon>();
        Debug.Log("Selected Weapon: " + weaponObjects[index].name);
    }
}