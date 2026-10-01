using UnityEngine;

public class DoorOpen : MonoBehaviour
{
    public float openAngle = 90f;
    public float rotationSpeed = 5f;
    public bool isOpen = false;
    public Quaternion closedRotation;
    public Quaternion openRotation;

    void Start()
    {
        closedRotation = transform.localRotation;
        openRotation = Quaternion.Euler(0f, openAngle, 0f) * closedRotation;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            isOpen = !isOpen;
        }

        Quaternion target = isOpen ? openRotation : closedRotation;
        transform.localRotation = Quaternion.Lerp(transform.localRotation, target, rotationSpeed * Time.deltaTime);
    }
}
