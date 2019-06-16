using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class PlayerInputMethodBase : MonoBehaviour, IPlayerInputMethod
{
    [SerializeField]private CinemachineVirtualCameraBase virtualCam;
    public CinemachineVirtualCameraBase VirtualCam => virtualCam;
    protected Animator anim;
    protected Camera cam;
    protected bool receiveInput = true;
    void Awake()
    {
        anim = this.GetComponent<Animator>();
        cam = Camera.main;
        GameController._onStateChange += OnGameStateChange;
    }

    protected virtual void OnGameStateChange(PlayerState newState)
    {
        if (newState is PlayerState.Walking)
            AllowInput();
        else
            IgnoreInput();
    }



    protected void IgnoreInput()
    {
        receiveInput = false;
        StopAnimation();
    }
    protected void AllowInput()
    {
        receiveInput = true;
    }

    protected void StopAnimation()
    {
        anim.SetFloat("InputMagnitude", 0);
        anim.SetFloat("InputZ", 0);
        anim.SetFloat("InputX", 0);
    }

    public virtual void UpdatePlayerMovement()
    {
        throw new System.NotImplementedException();
    }
}

public enum InputMethod
{
    Arrow = 0,
    Mouse = 1,
}

public interface IPlayerInputMethod
{
    CinemachineVirtualCameraBase VirtualCam { get; }
    void UpdatePlayerMovement();
}