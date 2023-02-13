using System;
using System.Collections;
using System.Collections.Generic;
using EmreBeratKR.ServiceLocator;
using UnityEngine;

public class Player : ServiceBehaviour
{
    [SerializeField] private float moveSpeed;

    private bool isWalking;
    
    private void Update()
    {
        Move();
    }

    private void Move()
    {
        var inputVector = ServiceLocator.Get<GameInput>().GetMovementVectorNormalized();
        
        Vector3 moveDir = new Vector3(inputVector.x, 0f, inputVector.y);
        
        transform.position += moveDir * (Time.deltaTime * moveSpeed);

        isWalking = moveDir != Vector3.zero;
        
        var rotateSpeed = 10;
        transform.forward = Vector3.Slerp(transform.forward, moveDir, Time.deltaTime * rotateSpeed);

        //transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(moveDir), Time.deltaTime * rotateSpeed );
    }

    public bool IsWalking()
    {
        return isWalking;
    }
}
