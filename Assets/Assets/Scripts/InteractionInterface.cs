public interface IInteraction
{
    string GetPrompt();
    void SetHighlight(bool on);
    void Interact(PlayerInventory player);
}