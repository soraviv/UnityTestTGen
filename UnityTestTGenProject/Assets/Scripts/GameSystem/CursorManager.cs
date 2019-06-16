using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorManager : MonoBehaviour
{
    private void Awake()
    {
        GameController._onStateChange += OnPlayerStateChange;
        Cursor.lockState = CursorLockMode.Confined;
        PlayerInputManager.OnInputMethodChange += CheckPlayerInputMethod;
    }

    private void OnPlayerStateChange(PlayerState newState)
    {
        switch (newState)
        {
            case PlayerState.Walking:
                CheckPlayerInputMethod();
                break;
            case PlayerState.Menu:
            case PlayerState.Sit:
                Cursor.visible = true;
                break;
        }
        
    }

    private void CheckPlayerInputMethod()
    {
        if (PlayerInputManager.PlayerInputMethod is CharacterMoveWithArrow)
            Cursor.visible = false;
        else
            Cursor.visible = true;
    }


}
