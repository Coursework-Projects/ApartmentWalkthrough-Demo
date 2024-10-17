using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateMachine : MonoBehaviour
{
    public Player player { get; private set; }
    private PlayerBaseState CurrentState { get;set; }

    private void Awake()
    {
        player = GetComponent<Player>();
    }
    private void Update()
    {
        //call the update/tick method and pass the delta-time
        CurrentState?.Tick(Time.deltaTime);
    }
    public void SwitchStates(PlayerBaseState state)
    {
       
        CurrentState?.Exit();
        CurrentState = state;
        CurrentState.Enter(this);
       
    }
}
