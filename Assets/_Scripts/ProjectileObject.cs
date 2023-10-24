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
    private Rigidbody2D Owner;
    //[SerializeField] private ProjectileSO stats;    [field: SerializeField] public float knockback { get; private set; }
    public float contactDamage ;
    public float baseSpeed; 
    public float lifeTime;


    public void Initialize(float chargepercent, Rigidbody2D Owner)
    {
        this.Owner = Owner;
        curDirection = transform.right;
        curSpeed = baseSpeed* chargepercent;
        curDamage = contactDamage * chargepercent;
        Destroy(gameObject, lifeTime * chargepercent);
    }
    // private void OnTriggerEnter2D(Collider2D collision)
    // {
    //     Rigidbody2D Other = collision.attachedRigidbody;
    //     if (Other == Owner)
    //         return;
    //     if(Other.TryGetComponent(out IDamagable hit))
    //     {
    //         hit.TakeDamage(curDamage);
    //         //PoolManager.UpdateDamageStat(hit.);
    //     }
    //     PoolManager.PlayParticle("Particle_Hit", transform.position, transform.rotation);
    //     Destroy(gameObject);
    // }

    // Update is called once per frame
    void Update()
    {
        transform.position += Time.deltaTime * curSpeed * curDirection;
    }
}
