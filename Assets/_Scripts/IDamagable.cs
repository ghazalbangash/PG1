using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamagable
{
    public void Die();
    public void TakeDamage(float damagetaken);
}
