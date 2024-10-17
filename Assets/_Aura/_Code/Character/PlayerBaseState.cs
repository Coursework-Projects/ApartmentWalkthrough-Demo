using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerBaseState 
{
    protected PlayerStateMachine stateMachine;
    public virtual void Enter(PlayerStateMachine _stateMachine)
    {
        stateMachine = _stateMachine;
    }
    public virtual void Tick(float _deltaTime) 
    { }
    public virtual void Exit() { }
}
