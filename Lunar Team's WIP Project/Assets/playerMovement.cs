using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
private float moveSpeed;
public float walkSpeed;
public float sprintSpeed;
private float airsprintSpeed;
private float airwalkSpeed;

public float acceleration;

public float jumpForce;
public float jumpCooldown;
public float airMultiplier;
bool readyToJump;

public KeyCode jumpKey = KeyCode.Space;
public KeyCode sprintKey = KeyCode.LeftShift;
public float groundDrag;
public float playerHeight;
public LayerMask whatIsGround;
bool grounded;

public Transform orientation;

float horizontalInput;
float verticalInput;

Vector3 moveDirection;

Rigidbody rb;

public MovementState state;

//crouching
public float crouchSpeed;
public float crouchYScale;
private float startYScale;

public KeyCode crouchKey = KeyCode.LeftControl;

//slopin'
public float maxSlopeAngle;
private RaycastHit slopeHit;

private bool exitingSlope;

//scripting

public enum MovementState{
    walking,
    sprinting,
    crouching,
    air
}

private void Start(){
    airsprintSpeed = sprintSpeed / 2;
    airwalkSpeed = walkSpeed / 2;
    rb = GetComponent<Rigidbody>();
    rb.freezeRotation = true;

    readyToJump = true;
    startYScale = transform.localScale.y;
}

private void StateHandler(){
    if (Input.GetKey(crouchKey)){
     state = MovementState.crouching;
     moveSpeed = crouchSpeed;
    }
    else if(grounded && Input.GetKey(sprintKey)){
        Debug.Log("hi1");
        state = MovementState.sprinting;
        moveSpeed = 20;
        acceleration = sprintSpeed;
    }
    else if(grounded){
        Debug.Log("hi2");
        state = MovementState.walking;
        moveSpeed = walkSpeed;
        acceleration = walkSpeed;
    }
    else if(Input.GetKey(sprintKey)){
        Debug.Log("hi3");
        state = MovementState.air;
        moveSpeed = airsprintSpeed;
        acceleration = sprintSpeed;
    }
    else{
        Debug.Log("hi3");
        state = MovementState.air;
        moveSpeed = airwalkSpeed;
        acceleration = walkSpeed;
    }
}

private void Update()
{
    grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.2f, whatIsGround);
       if(grounded){
        rb.drag = groundDrag;}
    else
    {
        rb.drag = 0;
    }
    MyInput();
    SpeedControl();
    StateHandler();

 
    
}

private void FixedUpdate()
{
    MovePlayer();
}
private void MyInput()
{
    horizontalInput = Input.GetAxisRaw("Horizontal");
    verticalInput = Input.GetAxisRaw("Vertical");

    if(Input.GetKey(jumpKey) && readyToJump && grounded)
    {
        readyToJump = false;
       
        Jump();
        Invoke(nameof(ResetJump), jumpCooldown);
    }
    if (Input.GetKeyDown(crouchKey)){
        transform.localScale = new Vector3(transform.localScale.x,crouchYScale, transform.localScale.z);
        rb.AddForce(Vector3.down * 5f, ForceMode.Impulse);
    }
    if (Input.GetKeyUp(crouchKey)){
        transform.localScale = new Vector3(transform.localScale.x, startYScale, transform.localScale.z);
    }
}

private void MovePlayer()
{
moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;

if (OnSlope() && !exitingSlope){
    rb.AddForce(GetSlopeMoveDirection() *  acceleration * 12f, ForceMode.Force);

    if(rb.velocity.y > 0)
      rb.AddForce(Vector3.down * 80f, ForceMode.Force);
}


else if(grounded)
  rb.AddForce(moveDirection.normalized * acceleration * 10f, ForceMode.Force);

else if(!grounded)
  rb.AddForce(moveDirection.normalized * acceleration * 10f * airMultiplier, ForceMode.Force);

  rb.useGravity = !OnSlope();
}

private void SpeedControl()
{
Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

if (OnSlope() && !exitingSlope){
    if(rb.velocity.magnitude > moveSpeed)
        rb.velocity = rb.velocity.normalized * moveSpeed;
}

else if(flatVel.magnitude > moveSpeed)
{
    Vector3 limitedVel = flatVel.normalized * moveSpeed;
    rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z);
}
}

private void Jump()
{
    exitingSlope = true;

    rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

    rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
}

private void ResetJump()
{
    readyToJump = true;
    exitingSlope = false;
}

private bool OnSlope(){
    if(Physics.Raycast(transform.position, Vector3.down, out slopeHit, playerHeight * 0.625f + 0.3f)){
      float angle = Vector3.Angle(Vector3.up, slopeHit.normal);
      return angle < maxSlopeAngle && angle != 0;
    }

    return false;
}

private Vector3 GetSlopeMoveDirection(){
    return Vector3.ProjectOnPlane(moveDirection, slopeHit.normal).normalized;
}

}
