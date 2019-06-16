using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PlayerInventory 
{
    public static System.Action OnItemCountChange;

    private static Dictionary<int, int> ItemCollected = new Dictionary<int, int>();

    public static void OnItemCollected(ICollectable item)
    {
        if (!ItemCollected.ContainsKey(item.ItemId))
            ItemCollected.Add(item.ItemId, 1);
        else
            ItemCollected[item.ItemId]++;
        OnItemCountChange?.Invoke();
    }

    public static int GetItemCount(int itemID)
    {
        if (ItemCollected.ContainsKey(itemID))
            return ItemCollected[itemID];
        else
            return 0;
    }
}
