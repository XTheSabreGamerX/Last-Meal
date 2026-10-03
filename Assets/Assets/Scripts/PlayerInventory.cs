using UnityEngine;
using System.Collections.Generic;

public class PlayerInventory : MonoBehaviour
{
    public int maxItems = 10;
    public List<string> items = new List<string>();

    public bool Add(string item)
    {
        if (items.Count >= maxItems) return false;
        items.Add(item);
        Debug.Log("Inventory: " + string.Join(", ", items));
        return true;
    }

    public bool Has(string item)
    {
        return items.Contains(item);
    }

    public bool Remove(string item)
    {
        return items.Remove(item);
    }
}
