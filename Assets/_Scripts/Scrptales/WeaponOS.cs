using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "WeaponStats", menuName = "MyScriptableObject/WeaponStats", order = 1)]
public class WeaponOS : ScriptableObject
{
    [field: Header("Weapon Base Stats")]
    [field: SerializeField] public float  timeBetweenAttacks;

    public WaitForSeconds CoolDown { get; private set; }
    [field: SerializeField] private float cooldown;

    private void OnEnable()
    {
        CoolDown = new WaitForSeconds(cooldown);
    }

}
