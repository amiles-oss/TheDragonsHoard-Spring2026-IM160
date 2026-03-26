using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float playerSpeed;
    private InputAction move;
    private Rigidbody rb;
    private Vector3 playerMovement;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        move = InputSystem.actions.FindAction("Move");
        move.performed += MovePerformed;
        move.canceled += MoveCanceled;
    }

    private void MovePerformed(InputAction.CallbackContext obj)
    {
        playerMovement.x = -obj.ReadValue<Vector2>().y * playerSpeed;
        playerMovement.z = obj.ReadValue<Vector2>().x * playerSpeed;
    }

    private void MoveCanceled(InputAction.CallbackContext obj)
    {
        playerMovement = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        rb.linearVelocity = new Vector3(playerMovement.x, rb.linearVelocity.y, playerMovement.z);
    }
}
