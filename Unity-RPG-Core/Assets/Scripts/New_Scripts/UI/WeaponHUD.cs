using UnityEngine;
using UnityEngine.UI;

public class WeaponHUD : MonoBehaviour
{
    [SerializeField] private Text weaponText;
    private void Awake()
    {
        WeaponManager.Instance.OnWeaponChanged += w => weaponText.text = w.ToString();
    }
}