public interface IInteraction
{
    void Interact();
    string GetPrompt();
    void SetHighlight(bool on);
}