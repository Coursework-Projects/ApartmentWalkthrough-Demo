using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This class receives from keyboard/mouse or device screen in case of mobile
//and routes it to relevant handlers via events
public class InputController : MonoBehaviour
{
    public Action<Vector2> OnMoveInput;
    public Action<float> OnMouseXInput;
    public Action<float> OnMouseYInput;

    private Vector2 movementInput;
    private void Update()
    {
        //get input values
       float yValue = Input.GetAxisRaw("Vertical");
       float xValue =  Input.GetAxisRaw("Horizontal");

        //create movement input vector
        movementInput = new Vector2(xValue, yValue);
        movementInput.Normalize();
        //fire events and pass the values
        OnMoveInput(movementInput); 
        OnMouseXInput(Input.GetAxisRaw("Mouse X"));
        OnMouseYInput(Input.GetAxisRaw("Mouse Y"));
    }
    
}
