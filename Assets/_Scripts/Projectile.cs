using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : Weapon
{
    [SerializeField] private ProjectileObject projectileFired;
    protected override void Attack(float chargePercent)
    {
        ProjectileObject current = Instantiate(projectileFired, transform.position, transform.rotation);
        current.Initialize(chargePercent,owner);
        current.gameObject.layer = gameObject.layer;
    }
   
}
