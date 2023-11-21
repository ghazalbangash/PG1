using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerControler : MonoBehaviour, IDamagable
{
   PlayerAction inputAction;
    Vector2 move;
    Vector2 rotate;

    Rigidbody rb;
    //public GameObject projectile;
    //public Transform projectilePos;

    [SerializeField]private Weapon weapon;
    private bool isAttacking;
    [SerializeField] private EnemyControler[] controlledMonsters;

    private float distanceToGround;
    bool isGrounded;    
    public float jump = 5f;
    public float walkSpeed = 5f;
  
    private Animator playerAnimator;

     public float health { get; set; }

    // Health testing
    //CharacterStats cs;

    private void Awake() {
        rb = GetComponent<Rigidbody>();
        Inputs.Init(this);

    }


    // 20 frames per second
    // 1/20 = 0.05
    // 20 * 1 * 10 * 0.05 = 10
    // 500 frames per second
    // 1/500 = 0.002
    // 500 * 1* 10 * 0.002 = 10
    private void Update() {
        transform.Translate(Vector3.forward * (move.y * Time.deltaTime * walkSpeed), Space.Self);
        transform.Translate(Vector3.right * (move.x * Time.deltaTime * walkSpeed),Space.Self);
        isGrounded = Physics.Raycast(transform.position, -Vector3.up,GetComponent<Collider>().bounds.extents.y);

    }


    public void Jump()

    {
        if(isGrounded){
        rb.velocity = new Vector3(rb.velocity.x, jump, rb.velocity.z);
         }

    }
    public void Move(Vector2 direction)
    {

        move = direction;
    }


    public  void shoot()
    {
        isAttacking = !isAttacking;
        if(isAttacking) weapon.StartAttack();
        else weapon.EndAttack();
        
        // Rigidbody rbBullet = Instantiate(projectile,projectilePos.position,Quaternion.identity).GetComponent<Rigidbody>();
        //rbBullet.AddForce(Vector3.forward*32f,ForceMode.Impulse);
    }


    public void TakeDamage(){

    }

    public void Die(){
        Destroy(gameObject);

    }

 
    public void MoveTo(Ray camToWorldRay)
    {
        Debug.DrawRay(camToWorldRay.origin, camToWorldRay.direction* 100, Color.blue,1);
        if (!Physics.Raycast(camToWorldRay, out RaycastHit hitObject, 100, staticutility.MoveLayers)) return;

        foreach (EnemyControler monster in controlledMonsters)
        {
            monster.MoveToTarget(hitObject.point);
        }

    }



}


