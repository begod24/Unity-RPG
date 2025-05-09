using UnityEngine;

public class PlayerAim : MonoBehaviour
{
    [SerializeField] private Transform cameraTransform;
    [SerializeField] private Transform playerBody;
    [SerializeField] private float sensitivity = 2f;
    private float xRot = 0f;

    private void Awake()
    {
        PlayerInputHandler.Instance.OnLook += HandleLook;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void HandleLook(Vector2 input)
    {
        xRot -= input.y * sensitivity;
        xRot = Mathf.Clamp(xRot, -90f, 90f);
        cameraTransform.localRotation = Quaternion.Euler(xRot, 0f, 0f);
        playerBody.Rotate(Vector3.up * input.x * sensitivity);
    }
}