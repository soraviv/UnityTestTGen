using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class DisplayItemCount : MonoBehaviour
{
    public int ItemID;
    public TextMeshProUGUI textObject;
    private int currentCount = -1;
    private void Awake()
    {
        PlayerInventory.OnItemCountChange += UpdateItemCount;
        UpdateItemCount();
    }

    void UpdateItemCount()
    {
        var count = PlayerInventory.GetItemCount(ItemID);
        if (count != currentCount)
        {
            currentCount = count;
            textObject.text = currentCount.ToString();
        }
    }
}
