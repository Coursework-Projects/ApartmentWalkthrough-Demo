using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractState : PlayerBaseState
{
    float yValue;
    public override void Enter(PlayerStateMachine _stateMachine)
    {
        base.Enter(_stateMachine);
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Tick(float _deltaTime)
    {
        stateMachine.transform.Rotate(Vector3.up * Input.GetAxisRaw("Mouse X"));
        yValue -= Input.GetAxisRaw("Mouse Y");

        yValue = Mathf.Clamp(yValue, stateMachine.player.minUpDownAngle, stateMachine.player.maxUpDownAngle);
        stateMachine.player.fpsCamTransform.localRotation = Quaternion.Euler(yValue, 0, 0);

        if (Input.GetKeyDown(KeyCode.W))
        {
            stateMachine.SwitchStates(new PlayerFPSState());
        }
    }
}
