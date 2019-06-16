using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableColisionDetector : MonoBehaviour
{
    public delegate void CollectItemEvent(ICollectable collectedItem);
    public CollectItemEvent CollectItem;
    void OnTriggerEnter(Collider other)
    {
        var collectable = other.GetComponent<ICollectable>();
        if (collectable != null)
        {
            collectable.OnCollected();
            PlayerInventory.OnItemCollected(collectable);
        }
    }
}