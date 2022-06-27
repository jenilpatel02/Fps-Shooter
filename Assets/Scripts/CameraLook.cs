
using UnityEngine;

public class CameraLook : MonoBehaviour
{
    public Transform player;
    float CameraVerticalRotation = 0f;
    bool LockPointer = true;
    public float mouseSensitivity = 2f;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float inputX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float inputY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        CameraVerticalRotation -= inputY;
        CameraVerticalRotation = Mathf.Clamp(CameraVerticalRotation, -90f, 90f);
        transform.localEulerAngles = Vector3.right * CameraVerticalRotation;

        player.Rotate(Vector3.up * inputX);
    }
}
