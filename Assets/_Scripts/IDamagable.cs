using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamagable
{

    public float health { get; set; }
    public void Die();
    public void TakeDamage(float damagetaken){
        health-= damagetaken;
        if(health <0){
            Die();
        }

    }
}
