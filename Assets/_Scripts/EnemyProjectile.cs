using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    // Start is called before the first frame update

    private float trueDamage;


    private void OnCollisionEnter(Collision other) {
        print(message:other.transform.name +", "+other.transform.root.name);


        // if(other.transform.root.TryGetComponent(out IDamagable hitTarget)){
        //     hitTarget.TakeDamage(trueDamage);
        // }

        // Destroy(gameObject);
        
    }

}
