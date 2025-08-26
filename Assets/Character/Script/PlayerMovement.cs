using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController PlayerControl;

    private Transform cameraTransform;
    private int moveSpeed;
    public int walkSpeed = 4;
    public int runSpeed = 8;
    public float gravity = -9.8f;
    public float jumpHeight = 1f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    
    Vector3 velocity;

    bool isGround;

    void Start()
    {
        cameraTransform = Camera.main.transform;
        //HiddenCursor
        Cursor.lockState = CursorLockMode.Locked;
        moveSpeed = walkSpeed;
    }
    
    void Update()
    {
        //Check Ground
        isGround = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGround && velocity.y < 0)
        {
            velocity.y = -2f;
        }
        
        //Movement
        playerMove();

        //Jump
        if (Input.GetButtonDown("Jump") && isGround)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
        
        velocity.y += gravity * Time.deltaTime;

        PlayerControl.Move(velocity * Time.deltaTime);
    }

    public void playerMove() 
    {
        float x = Input.GetAxis("Horizontal"); 
        float z = Input.GetAxis("Vertical");
        Vector3 move = cameraTransform.right * x + cameraTransform.forward * z;
        move.y = 0f;

        if (Input.GetKey(KeyCode.LeftShift) && z == 1)
        {
            moveSpeed = runSpeed;
        }
        else
        {
            moveSpeed = walkSpeed;
        }
        
        PlayerControl.Move(move * moveSpeed * Time.deltaTime);
    }
}
