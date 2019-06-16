using UnityEngine;

public interface ICharacter
{
    string Name { get; }
    Transform transform { get; }
    float GetHeight();
}

public interface IInteractableCharacter : ICharacter
{
    void OnSelected();
    void OnDeselected();
}
