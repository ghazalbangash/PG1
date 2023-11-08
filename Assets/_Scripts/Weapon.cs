using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    [SerializeField] protected WeaponSO myStats;
    private Coroutine timerCoroutine;
    protected float currentchargetime;
    private bool atkTimerdone = true;
    protected Rigidbody owner;




    [field: SerializeField] public float contactDamage { get; private set; }
    [field: SerializeField] public float chargeTime { get; private set; }
    [field: SerializeField] public float knockback { get; private set; }
    [field: SerializeField] public float cost { get; private set; }
    //[field: SerializeField, Range(0,1)] public float minCharge { get; private set; }
    //public WaitForSeconds CoolDown { get; private set; }
    //[SerializeField] private float cooldown;


    // private void OnEnable()
    // {
    //     CoolDown = new WaitForSeconds(cooldown);
    // }
    public float Getcost()
    {
        return cost;
    }
    protected abstract void Attack(float chargePercent);
    protected virtual bool CanAttack()
    {
        return atkTimerdone;
    }
    private void TryAttack(float percent)
    {
        if (percent < myStats.MinChargeTime)
        {
            return;
        }
        Attack(percent);
            StartCoroutine(CooldownTimer());         
    }
    private IEnumerator CooldownTimer()
    {
        atkTimerdone = false;
        yield return myStats.CoolDown;
        atkTimerdone = true;
    }
    public void StartAttack()
    {
        timerCoroutine = StartCoroutine(HandleCharge());
    }
    public void EndAttack()
    {
        StopCoroutine(timerCoroutine);
           TryAttack(currentchargetime / chargeTime);
    }
    private IEnumerator HandleCharge()
    {
        currentchargetime = 0;
        print("StartCharge");
        yield return new WaitUntil(()=>atkTimerdone);
        print("CooldownDone");
        while(currentchargetime < chargeTime)
        {
            currentchargetime += Time.deltaTime;
            yield return null;
        }
        print("AttackComplete");
        TryAttack(1);
        timerCoroutine = StartCoroutine(HandleCharge());
    }
    private void OnTransformParentChanged()
    {
        owner = transform.root.GetComponent<Rigidbody>();
    }
    private void Awake()
    {
        owner = transform.root.GetComponent<Rigidbody>();
    }
}
