using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class PlayerFPSState : PlayerBaseState
{
    //cache of Mouse Y axis input
    float yValue;
    public override void Enter(PlayerStateMachine _stateMachine)
    {
        base.Enter(_stateMachine);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        
        //Find Camera and attach it transform
        Camera.main.transform.SetParent(stateMachine.player.fpsCamTransform, false);
        Camera.main.transform.position = stateMachine.player.fpsCamTransform.position;
        Camera.main.transform.localRotation = stateMachine.player.fpsCamTransform.localRotation;
    }

    public override void Exit()
    {
        base.Exit();
       
    }

    public override void Tick(float _deltaTime)
    {
        

        stateMachine.transform.Rotate(Vector3.up * Input.GetAxisRaw("Mouse X"));
        yValue -= Input.GetAxisRaw("Mouse Y");

        yValue = Mathf.Clamp(yValue,stateMachine.player.minUpDownAngle,stateMachine.player.maxUpDownAngle);
        stateMachine.player.fpsCamTransform.localRotation = Quaternion.Euler(yValue,0,0);

        Vector3 moveDirection = CalculateMoveDirection();
        stateMachine.player.characterController.Move(moveDirection * _deltaTime * stateMachine.player.walkspeed);

        if (Input.GetKeyDown(KeyCode.I))
        {
            //switch to interact mode
            stateMachine.SwitchStates(new PlayerInteractState());
        }
    }

    private Vector3 CalculateMoveDirection()
    {
        Vector3 camForwardVector = stateMachine.player.fpsCamTransform.forward * stateMachine.player.movementInput.y;
        Vector3 camRightVector = stateMachine.player.fpsCamTransform.right * stateMachine.player.movementInput.x;

        camForwardVector.Normalize();
        camRightVector.Normalize();

        camForwardVector.y = 0;
        camRightVector.y = 0;

        return camForwardVector + camRightVector;
    }
}
