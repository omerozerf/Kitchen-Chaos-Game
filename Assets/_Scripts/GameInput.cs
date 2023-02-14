using System;
using System.Collections;
using System.Collections.Generic;
using EmreBeratKR.ServiceLocator;
using UnityEngine;

public class GameInput : MonoBehaviour
{
    public static GameInput Instance;


    private PlayerInputActions playerInputActions;
    
    private void Awake()
    {
        Instance = this;
        playerInputActions = new PlayerInputActions();
        playerInputActions.Player.Enable();
    }


    public Vector2 GetMovementVectorNormalized()
    {
        Vector2 inputVector = playerInputActions.Player.Move.ReadValue<Vector2>();
        
        inputVector = inputVector.normalized;
        
        return inputVector;
    }
}
