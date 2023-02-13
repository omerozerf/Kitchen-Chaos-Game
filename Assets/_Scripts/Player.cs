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
        Vector2 inputVector = new Vector2(0, 0);
        
        if (Input.GetKey(KeyCode.W))
        {
            inputVector.y = +1;
        }
        if (Input.GetKey(KeyCode.S))
        {
            inputVector.y = -1;
        }
        if (Input.GetKey(KeyCode.A))
        {
            inputVector.x = -1;
        }
        if (Input.GetKey(KeyCode.D))
        {
            inputVector.x = +1;
        }

        inputVector = inputVector.normalized;
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
