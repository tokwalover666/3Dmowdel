using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inputManager : MonoBehaviour
{
    private PlayerControl playerControl;

    public Vector2 movementInput;
    public float verticalInput;
    public float horizontalInput;

    public float moveAmount;

    public bool sprintInput;
    public bool walkIntput;
    private void OnEnable()
    {
        if(playerControl == null)
        {
            playerControl = new PlayerControl(); 
            //when WASD hit, record the movement to the variaable movementInput
            playerControl.PlayerControls.wasd.performed += i => movementInput = i.ReadValue<Vector2>();

            playerControl.PlayerActions.Sprint.performed += i => sprintInput = true;
            playerControl.PlayerActions.Sprint.canceled += i => sprintInput = false;

            playerControl.PlayerActions.Jump.performed += i => sprintInput = true;
            playerControl.PlayerActions.Jump.canceled += i => sprintInput = false;
        }
        playerControl.Enable();
    }

    private void OnDisable()
    {
        playerControl.Disable();
    }

    public void HandleAllInput()
    {
        HandleMovementInput();
        HandleSprintingInput();
    }

    private void HandleMovementInput()
    {
        verticalInput = movementInput.y;
        horizontalInput = movementInput.x;

        moveAmount = Mathf.Clamp01(Mathf.Abs(verticalInput) + Mathf.Abs(horizontalInput));
        playerManager.Instance.animatorManager.UpdateAnimatorValues(0, moveAmount, playerManager.Instance.isSprinting);
    }

    private void HandleSprintingInput()
    {
        if(sprintInput && moveAmount > 0.5)
        {
            playerManager.Instance.isSprinting = true;
        }
        else
        {
            playerManager.Instance.isSprinting = false;
        }
    }



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
