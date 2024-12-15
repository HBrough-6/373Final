using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Elizeo_PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed;
    public float groundDrag;
    public float jumpForce;
    public float jumpCooldown;
    public float airMultiplier;
    public bool jumpReady;

    [Header("KeyBinds")]
    public KeyCode jumpKey = KeyCode.Space;

    [Header("Ground Check")]
    public float height;
    public LayerMask whatisGround;
    public bool isGrounded;

    public Transform playerOri;

    private float horiInput;
    private float vertInput;

    private Vector3 moveDir;

    private Rigidbody playerRB;

    private void Start()
    {
        playerRB = GetComponent<Rigidbody>();
        playerRB.freezeRotation = true;
        jumpReady = true;
    }

    private void Update()
    {
        //Checks the ground
        isGrounded = Physics.Raycast(transform.position, Vector3.down, height * 0.5f + 0.2f, whatisGround);
       
        //Player Inputs
        playerInputs();

        //Controls Speed
        SpeedControl();

        //Handles the ground drag
        if (isGrounded)
        {
            playerRB.drag = groundDrag;
        }
        else
        {
            playerRB.drag = 0;
        }
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    private void playerInputs()
    {
        horiInput = Input.GetAxisRaw("Horizontal");
        vertInput = Input.GetAxisRaw("Vertical");

        //When to Jump
        if(Input.GetKey(jumpKey) && jumpReady && isGrounded)
        {
            jumpReady = false;

            Jump();

            Invoke(nameof(ResetJump), jumpCooldown);
        }
    }

    private void MovePlayer()
    {
        //Calculates movement direction
        moveDir = playerOri.forward * vertInput + playerOri.right * horiInput;

        //On the ground
        if (isGrounded)
        {
            playerRB.AddForce(moveDir.normalized * moveSpeed * 10f, ForceMode.Force);
        }

        //In the air
        else if(!isGrounded)
        {
            playerRB.AddForce(moveDir.normalized * moveSpeed * 10f * airMultiplier, ForceMode.Force);
        }
    }

    private void SpeedControl()
    {
        Vector3 flatVel = new Vector3(playerRB.velocity.x, 0f, playerRB.velocity.z);

        //Limit velocity if needed
        if (flatVel.magnitude > moveSpeed)
        {
            Vector3 limitedVel = flatVel.normalized * moveSpeed;
            playerRB.velocity = new Vector3(limitedVel.x, playerRB.velocity.y, limitedVel.z);
        }
    }

    private void Jump()
    {
        //resets y velocity
        playerRB.velocity = new Vector3(playerRB.velocity.x, 0f, playerRB.velocity.z);

        playerRB.AddForce(transform.up * jumpForce, ForceMode.Impulse);
    }

    private void ResetJump()
    {
        jumpReady = true;
    }
}
