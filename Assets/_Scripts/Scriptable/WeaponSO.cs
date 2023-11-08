using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[CreateAssetMenu(fileName = "WeaponStats", menuName = "MyScriptableObject/WeaponStats", order = 1)]
public class WeaponSO : ScriptableObject
{
    [field: Header("weapon Base Stats")]
    [field: SerializeField] public float timeBetweenAttacks {get; private set; }
    [field: SerializeField] public float ChargeUpTime {get; private set; }

    [field: SerializeField, Range(0,1)] public float MinChargeTime;
    [field: SerializeField] public bool IsFullyAuto;

    public WaitForSeconds CoolDown {get; private set; }

    private void OnEnable()
    {
        CoolDown = new WaitForSeconds(timeBetweenAttacks);
    }

}
