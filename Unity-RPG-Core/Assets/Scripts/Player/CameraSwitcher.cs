using UnityEngine;

public class CameraSwitcher : MonoBehaviour
{
    public Transform firstPersonCamera;
    public Transform thirdPersonCamera;
    public KeyCode switchKey = KeyCode.C;

    private bool isFirstPerson = true;

    void Start()
    {
        SetCameraView(true);
    }

    void Update()
    {
        if (Input.GetKeyDown(switchKey))
        {
            isFirstPerson = !isFirstPerson;
            SetCameraView(isFirstPerson);
        }
    }

    void SetCameraView(bool firstPerson)
    {
        firstPersonCamera.gameObject.SetActive(firstPerson);
        thirdPersonCamera.gameObject.SetActive(!firstPerson);
    }
}