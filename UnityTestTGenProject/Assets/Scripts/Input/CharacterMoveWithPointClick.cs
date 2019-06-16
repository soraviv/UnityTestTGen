using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMoveWithPointClick : PlayerInputMethodBase
{
    float StartAnimTime;

    public float desiredRotationSpeed;

    private Vector3 worldDestination;

    private bool moveToDestination = false;
    public override void UpdatePlayerMovement()
    {
        if (!receiveInput)
            return;
        if (Input.GetMouseButtonDown(0))
        {
            if (RaycastFromMouse(out RaycastHit hitInfo))
            {
                moveToDestination = true;
                worldDestination = hitInfo.point;
                Debug.DrawLine(worldDestination, worldDestination + Vector3.up * 10, Color.red, 10);
            }
        }
        if (DistanceFromDestination() > 0.2f && moveToDestination)
        {
            MoveCharacterForward();
            CharacterRotation();
        }
        else if (moveToDestination)
        {
            StopAnimation();
            moveToDestination = false;
        }
    }

    private bool RaycastFromMouse(out RaycastHit hitInfo)
    {
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        return Physics.Raycast(ray, out hitInfo, 100);
    }

    private void MoveCharacterForward()
    {
        anim.SetFloat("InputMagnitude", 1, StartAnimTime, Time.deltaTime);
    }

    void CharacterRotation()
    {
        var lookAtPosition = worldDestination;
        lookAtPosition.y = transform.position.y;
        transform.LookAt(lookAtPosition);
    }

    private float DistanceFromDestination()
    {
        worldDestination.y = transform.position.y;
        return Vector3.Distance(worldDestination, transform.position);
    }
}
