using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    public float interactRange = 3f;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Ray ray = new Ray(transform.position, transform.forward);

            if (Physics.Raycast(ray, out RaycastHit hit, interactRange))
            {
                IInteraction interactable = hit.collider.GetComponentInParent<IInteraction>();

                if (interactable != null)
                {
                    interactable.Interact();
                }
            }  
        }
    }
}