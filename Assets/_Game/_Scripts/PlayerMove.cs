using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMove : MonoBehaviour
{
    #region variables
    public Transform mainBody;
    public Rigidbody myBody;
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

    private void OnDisable()
    {
        inputActions.Disable();
    }

    private void Update()
    {
        moveInput = inputActions.pActionMap.Move.ReadValue<Vector2>();
        moveInput = Vector2.ClampMagnitude(moveInput, 1f);
    }

    private void FixedUpdate()
    {
        Vector3 forwardMovement = mainBody.forward * moveInput.y * moveSpeed * Time.fixedDeltaTime;
        myBody.MovePosition(myBody.position + forwardMovement);

        float turnAmount = moveInput.x * turnSpeed * Time.fixedDeltaTime;
        Quaternion turnRotation = Quaternion.Euler(0, turnAmount, 0);
        myBody.MoveRotation(myBody.rotation * turnRotation);
         myBody.velocity = Vector3.zero;
    }
}
