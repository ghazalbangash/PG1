using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : Weapon
{
    [SerializeField] private ProjectileObject projectileFired;
    [SerializeField] private Transform firePoint;
    protected override void Attack(float chargePercent)
    {
        //Note, we want the projectile to where the player is aiming.
        //So we can rotate the forward vector of the projectile by the camera rotation.
        //In the future, we can create a perfect direction vector of where the entity is looking,
        //by subtracting the point it's looking at, by it's position, and then saying Quaternion.LookAt()
        ProjectileObject current = Instantiate(projectileFired, firePoint.position, owner.transform.rotation);
        current.Initialize(chargePercent,owner);
        current.gameObject.layer = gameObject.layer;
    }
   
}
