using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    private CharacterController controller;

    private void Awake()
    {
        controller = GetComponent<CharacterController>();
        PlayerInputHandler.Instance.OnMove += HandleMove;
    }

    private void HandleMove(Vector2 input)
    {
        Vector3 dir = transform.right * input.x + transform.forward * input.y;
        controller.SimpleMove(dir * speed);
    }
}