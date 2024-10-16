using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMove : MonoBehaviour
{
    #region variables
    public Transform mainBody;
    public float moveSpeed = 5f;  
    public float turnSpeed = 100f;  

    private PlayerInputActions inputActions;  
    private Vector2 moveInput;  
    #endregion

    private void OnEnable()
    {
        inputActions = new PlayerInputActions();
        inputActions.Enable();
      
    }

    private void Update()
    {
        moveInput = inputActions.pActionMap.Move.ReadValue<Vector2>();
        Vector3 forwardMovement = mainBody.forward * moveInput.y * moveSpeed * Time.deltaTime;
        mainBody.position += forwardMovement;

        float turnAmount = moveInput.x * turnSpeed * Time.deltaTime;
        mainBody.Rotate(0, turnAmount, 0);
    }


}
