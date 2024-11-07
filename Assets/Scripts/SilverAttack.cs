// Ethan Brockman

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SilverAttack : MonoBehaviour
{
    private Animator ani;
    private bool chargeState = false;
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
    void Start()
    {
        ani = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
