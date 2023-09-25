using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerControler : MonoBehaviour
{
   PlayerAction inputAction;
    Vector2 move;
    Vector2 rotate;
    Rigidbody rb;

    private float distanceToGround;
    bool isGrounded;
    public float jump = 5f;
    public float walkSpeed = 5f;
  
    private Animator playerAnimator;

    // Health testing
    //CharacterStats cs;

    private void Awake() {
        inputAction = new PlayerAction();

        inputAction.Player.Move.performed += cntxt => move = cntxt.ReadValue<Vector2>();
        inputAction.Player.Move.canceled += cntxt => move = Vector2.zero;

        inputAction.Player.Jump.performed += cntxt => Jump();


        rb = GetComponent<Rigidbody>();
        playerAnimator = GetComponent<Animator>();


        distanceToGround = GetComponent<Collider>().bounds.extents.y;
        Debug.Log(distanceToGround);

        // cameraRotation = new Vector3(transform.rotation.x, transform.rotation.y, transform.rotation.z);
        // Cursor.lockState = CursorLockMode.Locked;
    }

    private void OnEnable() {
        inputAction.Player.Enable();
    }

    // 20 frames per second
    // 1/20 = 0.05
    // 20 * 1 * 10 * 0.05 = 10
    // 500 frames per second
    // 1/500 = 0.002
    // 500 * 1* 10 * 0.002 = 10
    private void Update() {
        //cameraRotation = new Vector3(cameraRotation.x + rotate.y, cameraRotation.y + rotate.x, cameraRotation.z);
        //transform.eulerAngles = new Vector3(transform.rotation.x, cameraRotation.y, transform.rotation.z);

        transform.Translate(Vector3.forward * move.y * Time.deltaTime * walkSpeed, Space.Self);
        transform.Translate(Vector3.right * move.x * Time.deltaTime * walkSpeed, Space.Self);

        isGrounded = Physics.Raycast(transform.position, -Vector3.up, distanceToGround);
        Debug.Log(isGrounded);
    }

    private void OnDisable() {
        inputAction.Player.Disable();
    }

    private void Jump()
    {
        if(isGrounded)
        {
            rb.velocity = new Vector3(rb.velocity.x, jump, rb.velocity.z);
        }
    }

    // private void Shoot()
    // {
    //     Rigidbody rbBullet = Instantiate(projectile, projectilePos.position, Quaternion.identity).GetComponent<Rigidbody>();
    //     rbBullet.AddForce(Vector3.forward * 32f, ForceMode.Impulse);
    // }
    private void OnCollisionEnter(Collision other) {
        Debug.Log("player"+other.gameObject.tag);
 
    }

}


