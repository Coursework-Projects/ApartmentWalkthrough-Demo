using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("References")]
    public InputController inputController;
    public PlayerStateMachine stateMachine;

    //FPS state references
    [field: SerializeField] public Transform fpsCamTransform { get; set; }
    [field: SerializeField] public float minUpDownAngle { get; set; }
    [field: SerializeField] public float maxUpDownAngle { get; set; }

    //read only properties
    [field:SerializeField]public float walkspeed { get; private set; }
    public Vector2 movementInput { get; private set; }
    public Animator animator { get; private set; }
    public CharacterController characterController { get; private set; }


    #region Mono Callbacks

    private void Awake()
    {
       
        animator = GetComponent<Animator>();
        characterController = GetComponent<CharacterController>();
    }
    private void OnEnable()
    {
        inputController.OnMoveInput += HandleMoveInput;
        inputController.OnMouseXInput += HandleMouseXInput;
        inputController.OnMouseYInput += HandleMouseYInput;
    }
    private void Start()
    {
        stateMachine.SwitchStates(new PlayerFPSState());
    }


    private void OnDisable()
    {
        inputController.OnMoveInput -= HandleMoveInput;
        inputController.OnMouseXInput -= HandleMouseXInput;
        inputController.OnMouseYInput -= HandleMouseYInput;
    } 

    #endregion


    #region Input Callbacks
    private void HandleMouseYInput(float obj)
    {
        
    }

    private void HandleMouseXInput(float obj)
    {
       

    }

    private void HandleMoveInput(Vector2 _moveInput)
    {
        movementInput = _moveInput;

        
    }
    #endregion
}
