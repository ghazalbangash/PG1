using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerControler : MonoBehaviour
{
   PlayerAction inputAction;
    Vector2 move;
    Vector2 rotate;
<<<<<<< Updated upstream
    Rigidbody rb;
=======

    Rigidbody rig;
    private float jumpSpeed = 5f;


>>>>>>> Stashed changes

    private float distanceToGround;

    public float walkSpeed = 5f;
  
    private Animator playerAnimator;

    bool isGround;
    public GameObject projectile;
    public Transform projectilePos;



    // Health testing
    //CharacterStats cs;

    private void Awake() {
<<<<<<< Updated upstream
        inputAction = new PlayerAction();

        inputAction.Player.Move.performed += cntxt => move = cntxt.ReadValue<Vector2>();
        inputAction.Player.Move.canceled += cntxt => move = Vector2.zero;

        inputAction.Player.Jump.performed += cntxt => Jump();


        rb = GetComponent<Rigidbody>();
        playerAnimator = GetComponent<Animator>();
=======


        Inputs.Init(this);
        rig = GetComponent<Rigidbody>();
>>>>>>> Stashed changes





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
<<<<<<< Updated upstream
        //cameraRotation = new Vector3(cameraRotation.x + rotate.y, cameraRotation.y + rotate.x, cameraRotation.z);
        //transform.eulerAngles = new Vector3(transform.rotation.x, cameraRotation.y, transform.rotation.z);
=======
        transform.Translate(Vector3.forward * (move.y * Time.deltaTime * walkSpeed), Space.Self);
        transform.Translate(Vector3.right * (move.x * Time.deltaTime * walkSpeed),Space.Self);
        isGround= Physics.Raycast(transform.position,-Vector3.up,GetComponent<Collider>().bounds.extents.y);



>>>>>>> Stashed changes

        transform.Translate(Vector3.forward * (move.y * Time.deltaTime * walkSpeed), Space.Self);
        transform.Translate(Vector3.right * (move.x * Time.deltaTime * walkSpeed), Space.Self);

        isGrounded = Physics.Raycast(transform.position, -Vector3.up,GetComponent<Collider>().bounds.extents.y);
        //Debug.Log(isGrounded);
    }

    private void OnDisable() {
        inputAction.Player.Disable();
    }

    public void Jump()
    {
<<<<<<< Updated upstream
        if(isGrounded)
        {
            rb.velocity = new Vector3(rb.velocity.x, jump, rb.velocity.z);
        }
=======
        if(isGround){
            rig.velocity = new Vector3(rig.velocity.x,jumpSpeed,rig.velocity.z);
        }

>>>>>>> Stashed changes
    }
    public void Move(Vector2 direction)
    {
        move = direction;
    }


    public void Shoot()
    {
        Rigidbody rbBullet = Instantiate(projectile, projectilePos.position, Quaternion.identity).GetComponent<Rigidbody>();
        rbBullet.AddForce(Vector3.forward * 32f, ForceMode.Impulse);
    }


    // public void SetLook(Vector2 direction)
    // {
    //     rotate = direction;
    //     //This is considered advanced rotation, but prevents gimbal lock...
    //     transform.rotation *= Quaternion.AngleAxis(direction.x * sensitivity, Vector3.up); // HORIZONTAL
    //     camFollowTarget.rotation *= Quaternion.AngleAxis(direction.y * -sensitivity, Vector3.right); // UP DOWN

    //     Vector3 angles = camFollowTarget.eulerAngles;
    //     float anglesX = angles.x;
    //     if (anglesX > 180 && anglesX < 360-viewAngleClamp)
    //     {
    //         anglesX =  360-viewAngleClamp;
    //     }
    //     else if (anglesX < 180 && anglesX > viewAngleClamp)
    //     {
    //         anglesX = viewAngleClamp;
    //     }
    //     //transform.rotation = Quaternion.Euler(0, angles.y, 0);
    //     camFollowTarget.localEulerAngles = new Vector3(anglesX, 0, 0);
    // }


    // private void OnCollisionEnter(Collision other) {
    //     Debug.Log("player"+other.gameObject.tag);
    //     isGrounded = true;
 
    // }
    // private void OnCollisionExit(Collision other) {
    //     isGrounded = false;
    // }

}


