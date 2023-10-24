using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerLocomotion : MonoBehaviour
{
    Vector3 moveDirection;
    Transform cameraObject;
    void Start()
    {
        cameraObject = Camera.main.transform;
    }

    public void HandlesAllMovement()
    {
        HandlesMovement();
        HandleRotation();
    }

    public void HandlesMovement()
    {
        moveDirection = cameraObject.forward * playerManager.Instance.InputManager.verticalInput;
        moveDirection = moveDirection + cameraObject.right * playerManager.Instance.InputManager.horizontalInput;
        moveDirection.Normalize();  
        moveDirection.y = 0;

        if (playerManager.Instance.isSprinting == true)
        {
            moveDirection = moveDirection * playerManager.Instance.sprintingSpeed;
        }
        else
        {
            if (playerManager.Instance.InputManager.moveAmount >= 0.5f)
            {
                moveDirection = moveDirection * playerManager.Instance.moveSpeed;
            }
            else
            {
                moveDirection = moveDirection * playerManager.Instance.runningSpeed;
            }
        }

        if (playerManager.Instance.isWalking == true)
        {
            moveDirection = moveDirection * playerManager.Instance.walkingSpeed;
        }
        else
        {
            moveDirection = moveDirection * playerManager.Instance.runningSpeed;
        }

        Vector3 movementVelocity = moveDirection;

        playerManager.Instance.RigidBody.velocity = movementVelocity;





    }

    public void HandleRotation()
    {
        Vector3 targetDirection = Vector3.zero;
        targetDirection = cameraObject.forward * playerManager.Instance.InputManager.verticalInput;
        targetDirection = targetDirection + cameraObject.right * playerManager.Instance.InputManager.horizontalInput;
        targetDirection.Normalize();
        targetDirection.y = 0;

        if (targetDirection == Vector3.zero)
        {
            targetDirection = transform.forward;
        }

        Quaternion targetRotataion = Quaternion.LookRotation(targetDirection);
        Quaternion playerRotation = Quaternion.Slerp(transform.rotation, targetRotataion, playerManager.Instance.rotationSpeed);
        transform.rotation = playerRotation;
    }


}
