using UnityEngine;

public class IngredientPile : MonoBehaviour, IInteraction
{
    public string ingredientName = "Ingredient";
    public Outline outline;

    public string GetPrompt()
    {
        return "Take " + ingredientName;
    }
    
    public void Interact (PlayerInventory player)
    {
        if (!player.Add(ingredientName))
        {
            Debug.Log("Your inventory's full");
        }
    }

    public void SetHighlight(bool on)
    {
        outline.enabled = on;
    }
}
