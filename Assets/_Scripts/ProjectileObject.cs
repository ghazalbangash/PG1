using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net.Security;



public class ProjectileObject : MonoBehaviour
{
    // Start is called before the first frame update
    private float curSpeed;
    private float curDamage;
    private Vector3 curDirection;
    private Rigidbody Owner;
    //[SerializeField] private ProjectileSO stats;    [field: SerializeField] public float knockback { get; private set; }
    public float contactDamage ;
    public float baseSpeed; 
    public float lifeTime;


    public void Initialize(float chargepercent, Rigidbody Owner)
    {
        this.Owner = Owner;
        curDirection = transform.right;
        curSpeed = baseSpeed* chargepercent;
        curDamage = contactDamage * chargepercent;
        
        GetComponent<Rigidbody>().AddForce(transform.forward * curSpeed, ForceMode.Impulse);
        
        Destroy(gameObject, lifeTime * chargepercent);
    }

}
