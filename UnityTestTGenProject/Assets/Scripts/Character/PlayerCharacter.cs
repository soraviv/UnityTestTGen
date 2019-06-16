using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : MonoBehaviour, ICharacter
{
    private string characterName;
    public string Name => characterName;
    [SerializeField] private Collider hardCollider;
    private Rigidbody rigidbody;
    

    void Awake()
    {
        hardCollider = GetComponent<Collider>();
        rigidbody = GetComponent<Rigidbody>();
        GameController._onStateChange += ChangeRigidbodyState;
    }

    public float GetHeight()
    {
        return hardCollider.bounds.max.y - hardCollider.bounds.min.y;
    }

    private void ChangeRigidbodyState(PlayerState newState)
    {
        switch (newState)
        {
            case PlayerState.Walking:
                rigidbody.isKinematic = false;
                break;
            default:
                rigidbody.isKinematic = true;
                break;
        }
    }

    public void SetCharacterName(string name)
    {
        characterName = name;
        GetComponentInChildren<NameTagUI>().SetNameText(characterName);
    }

}
