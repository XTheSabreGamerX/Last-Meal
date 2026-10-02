using System.Collections;
using UnityEngine;

public class DoorOpen : MonoBehaviour, IInteraction
{
    public float openAngle = 90f;
    public float rotationSpeed = 5f;
    public bool isOpen = false;

    private Quaternion closedRotation;
    private Quaternion openRotation;
    private Coroutine currentCourotine;

    public string doorName = "Fridge";
    public string GetPrompt()
    {
        return isOpen ? "Close " + doorName : "Open " + doorName;
    }

    public Outline outline;
    public void SetHighlight(bool off)
    {
        outline.enabled = off;
    }

    void Start()
    {
        closedRotation = transform.rotation;
        openRotation = Quaternion.Euler(transform.eulerAngles + new Vector3(0, openAngle, 0));
    }

    /*void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (currentCourotine != null) StopCoroutine(currentCourotine);
            currentCourotine = StartCoroutine(ToggleDoor());
        }
    }*/

    public void Interact()
    {
        if (currentCourotine != null) StopCoroutine(currentCourotine);
        currentCourotine = StartCoroutine(ToggleDoor());
    }

    private IEnumerator ToggleDoor()
    {
        Quaternion targetRotation = isOpen ? closedRotation : openRotation;
        isOpen = !isOpen;

        while (Quaternion.Angle(transform.rotation, targetRotation) > 0.01f)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * rotationSpeed);
            yield return null;
        }

        transform.rotation = targetRotation;
    }
}
