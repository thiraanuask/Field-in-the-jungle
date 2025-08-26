using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class PlayerMovementAnother : MonoBehaviour
{
    public CharacterController PlayerControl;
    
    private int moveSpeed;
    public int walkSpeed = 4;
    public int runSpeed = 8;
    public float gravity = -9.8f;
    public float jumpHeight = 1f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    public Animator gunAnimator;
    public Animator playerAnimator;

    public AudioClip[] footstepSounds;
    public AudioClip jumpSound;
    private AudioSource audioSource;
    private float timeToMove = 0.5f;
    private float nextMove = 0f;
    
    Vector3 velocity;

    bool isGround;
    
    void Start()
    {
        //HiddenCursor
        Cursor.lockState = CursorLockMode.Locked;
        moveSpeed = walkSpeed;
        
        audioSource = GetComponent<AudioSource>();
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
            JumpSound();
        }
        
        velocity.y += gravity * Time.deltaTime;

        PlayerControl.Move(velocity * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.Escape) && !SingletonGameApplicationManager.Instance.IsKeyLockMenuActive)
        {
            SingletonGameApplicationManager.Instance.IsKeyLockMenuActive = true;
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && SingletonGameApplicationManager.Instance.IsKeyLockMenuActive)
        {
            SingletonGameApplicationManager.Instance.IsKeyLockMenuActive = false;
        }

        if (SingletonGameApplicationManager.Instance.IsKeyLockMenuActive)
        {
            Cursor.lockState = CursorLockMode.Confined;
            Time.timeScale = 0;
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
            Time.timeScale = 1;
        }
    }

    public void playerMove() 
    {
        float x = Input.GetAxis("Horizontal"); 
        float z = Input.GetAxis("Vertical");
        Vector3 move = transform.right * x + transform.forward * z;
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
        
        //Animation
        float gunIsWalk = Mathf.Abs(x) + Mathf.Abs(z);
        float playerIsWalk = Mathf.Abs(x) + Mathf.Abs(z);
        gunAnimator.SetFloat(("IsWalk"), gunIsWalk);
        playerAnimator.SetFloat(("IsWalk"), playerIsWalk);
        if (playerIsWalk != 0 && Time.time >= nextMove)
        {
            if (Input.GetKey(KeyCode.LeftShift) && z == 1)
            {
                timeToMove = 0.3f;
            }
            else
            {
                timeToMove = 0.5f;
            }
            nextMove = Time.time + timeToMove;
            WalkSound();
        }
        else
        {
        }
    }

    private void JumpSound()
    {
        audioSource.clip = jumpSound;
        audioSource.Play();
    }

    private void WalkSound()
    {
        if (!isGround)
        {
            return;
        }
        int n = Random.Range(1, footstepSounds.Length);
        audioSource.clip = footstepSounds[n];
        audioSource.PlayOneShot(audioSource.clip);

        footstepSounds[n] = footstepSounds[0];
        footstepSounds[0] = audioSource.clip;
    }
}
