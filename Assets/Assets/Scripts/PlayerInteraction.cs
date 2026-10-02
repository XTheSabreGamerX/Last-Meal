using TMPro;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    public float interactRange = 3f;
    public TMP_Text promptText;

    private IInteraction current;
    private IInteraction previous;

    void Update()
    {
        current = null;

        Ray ray = new Ray(transform.position, transform.forward);
        if (Physics.Raycast(ray, out RaycastHit hit, interactRange))
        {
            current = hit.collider.GetComponentInParent<IInteraction>();
        }

        if (current != previous)
        {
            previous?.SetHighlight(true);
            current?.SetHighlight(false);
            previous = current;
        }

        promptText.text = current != null ? current.GetPrompt() : "";

        if (current != null && Input.GetKeyDown(KeyCode.Mouse0))
        {
            current.Interact();
        }
    }
}