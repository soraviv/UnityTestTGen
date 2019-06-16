using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Source: https://www.youtube.com/channel/UCH1svLGqmyVuCnHCHDr0EXw
public class CharacterMoveWithArrow : PlayerInputMethodBase
{
    private float InputX;
    private float InputZ;
    private Vector3 desiredMoveDirection;
    private bool blockRotationPlayer;
    public float desiredRotationSpeed = 0.1f;
    public float Speed;
    public float allowPlayerRotation = 0.1f;

    [Header("Animation Smoothing")]
    [Range(0, 1f)]
    public float HorizontalAnimSmoothTime = 0.2f;
    [Range(0, 1f)]
    public float VerticalAnimTime = 0.2f;
    [Range(0, 1f)]
    public float StartAnimTime = 0.3f;
    [Range(0, 1f)]
    public float StopAnimTime = 0.15f;

    public override void UpdatePlayerMovement()
    {
        if (receiveInput)
            InputMagnitude();
    }

    void PlayerMoveAndRotation()
    {
        InputX = Input.GetAxis("Horizontal");
        InputZ = Input.GetAxis("Vertical");

        cam = Camera.main;
        var forward = cam.transform.forward;
        var right = cam.transform.right;

        forward.y = 0f;
        right.y = 0f;

        forward.Normalize();
        right.Normalize();

        desiredMoveDirection = forward * InputZ + right * InputX;

        if (blockRotationPlayer == false)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(desiredMoveDirection), desiredRotationSpeed);
        }
    }

    void InputMagnitude()
    {
        //Calculate Input Vectors
        InputX = Input.GetAxis("Horizontal");
        InputZ = Input.GetAxis("Vertical");

        anim.SetFloat("InputZ", InputZ, VerticalAnimTime, Time.deltaTime * 2f);
        anim.SetFloat("InputX", InputX, HorizontalAnimSmoothTime, Time.deltaTime * 2f);

        //Calculate the Input Magnitude
        Speed = new Vector2(InputX, InputZ).sqrMagnitude;

        //Physically move player
        if (Speed > allowPlayerRotation)
        {
            anim.SetFloat("InputMagnitude", Speed, StartAnimTime, Time.deltaTime);
            PlayerMoveAndRotation();
        }
        else if (Speed < allowPlayerRotation)
        {
            anim.SetFloat("InputMagnitude", Speed, StopAnimTime, Time.deltaTime);
        }
    }
}


