using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    #region
    public static Transform instance;

    void Awake()
    {
        instance = this.transform;
    }
    #endregion

    [Header("Move Variables")]
    [SerializeField] float moveSpeed;
    [SerializeField] float walkSpeed;
    [SerializeField] float runSpeed;
    [SerializeField] float jumpForce;

    Vector3 moveDirection = Vector3.zero;

    CharacterController controller;

    [Header("Gravity")]
    [SerializeField] float gravity;
    [SerializeField] float groundDistance;
    [SerializeField] LayerMask groundMask;
    [SerializeField] bool isCharacterGrounded = false;
    Vector3 velocity = Vector3.zero;

    public VariableJoystick joystick;
    Animator anim;

    void Start()
    {
        GetReferences();

        InitVariables();
    }

    void Update()
    {
        HandleIsGrounded();
        HandleJumping();
        HandleGravity();
        HandleRunning();
        HandleMovement();
        HandleAnimations();
        TouchHandleRunning();
    }

    void HandleMovement()
    {
        /*
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");
        */

        float moveX = joystick.Horizontal;
        float moveZ = joystick.Vertical;

        moveDirection = new Vector3(moveX, 0, moveZ);
        moveDirection = moveDirection.normalized;
        moveDirection = transform.TransformDirection(moveDirection);

        controller.Move(moveDirection * moveSpeed * Time.deltaTime);
    }

    void HandleRunning()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            moveSpeed = runSpeed;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            moveSpeed = walkSpeed;
        }
    }

    public void TouchHandleRunning()
    {
        if (joystick.Vertical >= (float)0.8)
        {
            moveSpeed = runSpeed;
        }
        if (joystick.Vertical <= (float)0.8)
        {
            moveSpeed = walkSpeed;
        }
    }

    void HandleAnimations()
    {
        if(moveDirection == Vector3.zero)
        {
            anim.SetFloat("Speed", 0f, 0.2f, Time.deltaTime);
        }
        else if(moveDirection != Vector3.zero && !Input.GetKey(KeyCode.LeftShift))
        {
            anim.SetFloat("Speed", 0.5f, 0.2f, Time.deltaTime);
        }
        else if(moveDirection != Vector3.zero && Input.GetKey(KeyCode.LeftShift))
        {
            anim.SetFloat("Speed", 1f, 0.2f, Time.deltaTime);
        }
    }

    void HandleIsGrounded()
    {
        isCharacterGrounded = Physics.CheckSphere(transform.position, groundDistance, groundMask);
    }

    void HandleGravity()
    {
        if (isCharacterGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }

    void HandleJumping()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isCharacterGrounded)
        {
            velocity.y += Mathf.Sqrt(jumpForce * -2f * gravity);
        }
    }

    public void HandleTouchJumping()
    {
        if (isCharacterGrounded)
        {
            velocity.y += Mathf.Sqrt(jumpForce * -2f * gravity);
        }
    }

    void GetReferences()
    {
        controller = GetComponent<CharacterController>();
        anim = GetComponentInChildren<Animator>();
    }

    void InitVariables()
    {
        moveSpeed = walkSpeed;
    }
}
