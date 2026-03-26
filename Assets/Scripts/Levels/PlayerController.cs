/*****************************************************************************
// File Name : PlayerController.cs
// Author : Alan Miles
// Creation Date : March 25, 2026
//
// Brief Description : Allows the player to move in any direction besides 
                       up and down
******************************************************************************/
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float playerSpeed;
    private InputAction move;
    private Rigidbody rb;
    private Vector3 playerMovement;

    /// <summary>
    /// Sets variables and adds input actions
    /// </summary>
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        move = InputSystem.actions.FindAction("Move");
        move.performed += MovePerformed;
        move.canceled += MoveCanceled;
    }

    /// <summary>
    /// Allows the player to move forward, backward, left and right
    /// </summary>
    /// <param name="obj"></param>
    private void MovePerformed(InputAction.CallbackContext obj)
    {
        playerMovement.x = -obj.ReadValue<Vector2>().y * playerSpeed;
        playerMovement.z = obj.ReadValue<Vector2>().x * playerSpeed;
    }

    /// <summary>
    /// Makes the player stop when buttons are not being pressed
    /// </summary>
    /// <param name="obj"></param>
    private void MoveCanceled(InputAction.CallbackContext obj)
    {
        playerMovement = Vector3.zero;
    }

    /// <summary>
    /// Makes the player move
    /// </summary>
    void Update()
    {
        rb.linearVelocity = new Vector3(playerMovement.x, rb.linearVelocity.y, playerMovement.z);
    }
}
