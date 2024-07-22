using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    #region MovementVariables
    [Header("Movement")]
    public float walkSpeed = 6f;
    public float runSpeed = 12f;
    public float JumpPower = 7f;
    public float gravity = 10f;

    [SerializeField] private bool isWalking = false;

    private Vector3 initialPosition;
    #endregion

    #region MouseAndCameraVariables
    [Header("Mouse look & Camera")]
    public float lookSpeed = 2f;
    public float lookXLimit = 45f;
    public Camera playerCamera;
    public float amplitude = 0.1f;  // Height of bobbing effect
    public float frequency = 1.0f;  // Speed of bobbing effect
    #endregion

    #region ShootVariables
    [Header("Shoot")]
    public bool Shoot;
    #endregion

    #region PrivateVariables
    private Vector3 moveDirection = Vector3.zero;
    private float rotationX = 0;
    private bool canMove = true;
    #endregion

    #region PrivateScriptReferences
    private CharacterController _characterController;
    #endregion

    void Start()
    {
        _characterController = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        
        // CAM bob effect
        initialPosition = playerCamera.transform.localPosition;
    }

    void Update()
    {
        HandleMovement();
        HandleRotation();
    }

    private void HandleMovement()
    {
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Vector3 right = transform.TransformDirection(Vector3.right);

        // Shift to run
        bool isRunning = Input.GetKey(KeyCode.LeftShift);
        float curSpeedX = canMove ? (isRunning ? runSpeed : walkSpeed) * Input.GetAxis("Vertical") : 0;
        float curSpeedY = canMove ? (isRunning ? runSpeed : walkSpeed) * Input.GetAxis("Horizontal") : 0;
        float movementDirectionY = moveDirection.y;
        moveDirection = (forward * curSpeedX) + (right * curSpeedY);
        
        isWalking = curSpeedX != 0 || curSpeedY != 0;

        // Jumping
        if (Input.GetButton("Jump") && canMove && _characterController.isGrounded)
        {
            moveDirection.y = JumpPower;
        }
        else
        {
            moveDirection.y = movementDirectionY;
        }

        if (!_characterController.isGrounded)
        {
            moveDirection.y -= gravity * Time.deltaTime;
        }

        _characterController.Move(moveDirection * Time.deltaTime);

        // Camera bob effect
        if (isWalking)
        {
            float newY = initialPosition.y + Mathf.Sin(Time.time * frequency) * amplitude;
            playerCamera.transform.localPosition = new Vector3(initialPosition.x, newY, initialPosition.z);
            Debug.Log("Camera bobbing, newY: " + newY);
        }
        else
        {
            playerCamera.transform.localPosition = initialPosition;
            Debug.Log("Camera reset, initialPosition: " + initialPosition);
        }
    }
    

    private void HandleRotation()
    {
        if (canMove)
        {
            rotationX += -Input.GetAxis("Mouse Y") * lookSpeed;
            rotationX = Mathf.Clamp(rotationX, -lookXLimit, lookXLimit);
            playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
            transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * lookSpeed, 0);
        }
    }
}