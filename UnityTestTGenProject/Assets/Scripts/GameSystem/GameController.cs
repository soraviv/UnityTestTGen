using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    private static GameController _instance;
    public static PlayerState CurrentPlayerState { get; private set; }
    public delegate void OnStateChange(PlayerState newState);
    public static OnStateChange _onStateChange;
    [SerializeField] private PlayerState startState;
    [SerializeField] private CharacterSelector characterSelector;

    void Awake()
    {
        _instance = this;
    }

    private void Start()
    {
        if (startState is PlayerState.Menu)
            characterSelector.gameObject.SetActive(true);
        SetPlayerState(startState);
    }

    public static void SetPlayerState(PlayerState newState)
    {
        if (CurrentPlayerState != newState)
        {
            CurrentPlayerState = newState;
            _onStateChange?.Invoke(CurrentPlayerState);
        }
    }
}


public enum PlayerState
{
    None = 0,
    Menu = 1,
    Walking = 2,
    Sit = 3,
}