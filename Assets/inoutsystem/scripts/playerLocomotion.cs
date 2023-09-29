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
        moveDirection = cameraObject.right * playerManager.Instance.InputManager.horizontalInput;
        moveDirection.Normalize();
        moveDirection.y = 0;
        moveDirection = moveDirection * playerManager.Instance.Speed;
        Vector3 movementVelocity = moveDirection;
        playerManager.Instance.Rigidbody.velocity = movementVelocity;

    }

    public void HandleRotation()
    {

    }

}
