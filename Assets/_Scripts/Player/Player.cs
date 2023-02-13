using System;
using System.Collections;
using System.Collections.Generic;
using EmreBeratKR.ServiceLocator;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float moveSpeed;

    
    public static Player Instance;
    private bool isWalking;


    private void Awake()
    {
        Instance = this;
    }


    private void Update()
    {
        Move();
        
        
    }

    private void Move()
    {
        var inputVector = GameInput.Instance.GetMovementVectorNormalized();
        
        Vector3 moveDir = new Vector3(inputVector.x, 0f, inputVector.y);

        float moveDistance = moveSpeed * Time.deltaTime;
        var playerRadius = .7f;
        var playerHeight = 2f;
        bool canMove = !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerHeight,
            playerRadius, moveDir, moveDistance);

        if (!canMove)
        {
            // Cannot move towards moveDir
            
            // Attempt only X movement
            
        }

        if (canMove)
        {
            transform.position += moveDir * (Time.deltaTime * moveSpeed);
        }
        
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
