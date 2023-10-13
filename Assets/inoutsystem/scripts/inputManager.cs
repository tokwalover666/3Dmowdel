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
    private void OnEnable()
    {
        if(playerControl == null)
        {
            playerControl = new PlayerControl(); 
            //when WASD hit, record the movement to the variaable movementInput
            playerControl.PlayerControls.wasd.performed += i => movementInput = i.ReadValue<Vector2>();
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
    }

    private void HandleMovementInput()
    {
        verticalInput = movementInput.y;
        horizontalInput = movementInput.x;

        moveAmount = Mathf.Clamp01(Mathf.Abs(verticalInput) + Mathf.Abs(horizontalInput));
        playerManager.Instance.animatorManager.UpdateAnimatorValues
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
