using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    private PlayerMovement movement;
    private PlayerAim aim;
    private PlayerShoot shoot;

    private void Awake()
    {
        movement = GetComponent<PlayerMovement>();
        aim = GetComponent<PlayerAim>();
        shoot = GetComponent<PlayerShoot>();
    }
}