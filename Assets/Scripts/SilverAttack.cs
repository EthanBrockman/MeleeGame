// Ethan Brockman

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SilverAttack : MonoBehaviour
{
    GameObject ShieldInstance;
    MeleeGameBehavior meleeGameBehavior;
    private Animator ani;
    private bool chargeState = false;
    bool isAttacking = false;
    float damageDelay = 4;
    
    public void Attack() // Call this to activate the attack
    {
        ani.SetTrigger("SilverAttack");
    }
    public void StateTrue()
    {
        chargeState = true;
    }
    public void StateFalse()
    {
        chargeState = false;
    }
    public bool GetState()
    {
        return chargeState;
    }
    public void Charge()
    {
        ani.SetTrigger("IsCharging");
    }

    public void TurnOnAttack()
    {

        isAttacking = true;
    }
    public void TurnOffAttack()
    {
        isAttacking = false;
    }
    public void OnCollisionEnter(Collision collision)
    {
        
        GameObject x = GameObject.Find("Game Manager");
        playerDummyHitbox playerDummyHitbox1;
        bool isPlayer = collision.gameObject.TryGetComponent<playerDummyHitbox>(out playerDummyHitbox1);
        if (isAttacking && isPlayer && damageDelay <= 0)
        {
            if (ShieldInstance.GetComponent<ShieldAnimations>().ShieldIsPlaying)
            {


                x.GetComponent<MeleeGameBehavior>().HP -= 1;
                damageDelay = 2;
            }
        }
    }
    void Start()
    {
        ShieldInstance = GameObject.FindGameObjectWithTag("Player");
        ani = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        damageDelay -= Time.deltaTime;
    }
}
