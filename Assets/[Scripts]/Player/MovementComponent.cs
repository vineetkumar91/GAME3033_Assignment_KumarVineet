using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MovementComponent : MonoBehaviour
{
    // Movement
    [Header("Movement Factors")] 
    [SerializeField]
    private float walkSpeed = 5f;
    [SerializeField]
    private float sprintSpeed = 10f;
    [SerializeField]
    private float jumpForce = 5f;


    // Components
    private PlayerController _playerController;
    private Rigidbody m_rb;

    // References
    private Vector2 inputVector = Vector2.zero;         // Input Forward, Right
    private Vector3 moveDirection = Vector3.zero;       // Movement in 3 axis -> x, y, z

    /// <summary>
    /// Awake is before start, hence using it
    /// </summary>
    private void Awake()
    {
        _playerController = GetComponent<PlayerController>();
        m_rb = GetComponent<Rigidbody>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // if input vector magnitude is 0 or less, set to 0 : meaning we are not giving input
        if (!(inputVector.magnitude > 0))
        {
            moveDirection = Vector3.zero;
        }

        // get direction of movement with transforms forward and right
        moveDirection = transform.forward * inputVector.y + transform.right * inputVector.x;

        // set current speed -> sprint speed or walk speed
        float currentSpeed = _playerController.isRunning ? sprintSpeed : walkSpeed;

        // create a vector using the direction and speed        ... Use velocity+physics instead of change of position
        Vector3 movementDirection = moveDirection * (currentSpeed * Time.deltaTime);
        transform.position += movementDirection;
    }

    //-------------------------------------- Movement Functions --------------------------------------//

    /// <summary>
    /// Movement using the input system
    /// </summary>
    /// <param name="value">input value</param>
    public void OnMovement(InputValue value)
    {
        // Update input vector from the InputValue
        inputVector = value.Get<Vector2>();
    }

    /// <summary>
    /// Sprinting function
    /// </summary>
    /// <param name="value">input value</param>
    public void OnSprint(InputValue value)
    {
        // bug: Player is able to sprint when jumping.. find the right conditions here
        //if (!_playerController.isJumping)
        //{
            // update player controller bool from isPressed of InputValue
            _playerController.isRunning = value.isPressed;
        //}
    }

    /// <summary>
    /// Jump function
    /// </summary>
    /// <param name="value">input value</param>
    public void OnJump(InputValue value)
    {
        // if jumping, then discard further lines of executions
        if (_playerController.isJumping)
        {
            return;
        }

        // update player controller bool from isPressed of InputValue
        _playerController.isJumping = value.isPressed;

        // Impulse force upwards
        m_rb.AddForce((transform.up + moveDirection) * jumpForce, ForceMode.Impulse);
    }


    private void OnCollisionEnter(Collision other)
    {
        // Compare tag of Grounded first
        if (other.gameObject.CompareTag("Ground"))
        {
            if (!_playerController.isJumping)
            {
                return;
            }

            // Colliding with ground.. means not jumping
            _playerController.isJumping = false;
        }
    }
}
