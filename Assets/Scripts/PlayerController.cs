using UnityEngine;

public class PlayerController : MonoBehaviour
{
    bool LockPointer = true;
    private void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
    void movement()
    {
        var verticalspeed = Input.GetAxis("Vertical") * 5;
        var horizontalspeed = Input.GetAxis("Horizontal") * 5;

        transform.Translate(Vector3.forward * verticalspeed * Time.deltaTime);
        transform.Translate(Vector3.right * horizontalspeed * Time.deltaTime);
    }
    private void Update()
    {
        movement();
        
    }
}
