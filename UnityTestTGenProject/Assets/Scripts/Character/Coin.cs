using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour, ICollectable
{
    [SerializeField] private int itemId;
    public int ItemId => itemId;
    private bool collected = false;
    public void OnCollected()
    {
        if (!collected)
        {
            collected = true;
            //update player inventory
            LeanTween.moveY(gameObject, gameObject.transform.position.y + 0.5f, 0.5f).setEaseOutBack().setOnComplete(() => Destroy(gameObject));
        }
    }
}
