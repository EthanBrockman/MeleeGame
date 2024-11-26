// Ethan Brockman

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RustedAttack : MonoBehaviour
{
    GameObject ShieldInstance;
    Animator ani;
    bool isAttacking = false;
    float damageDelay = 2;
    [SerializeField] ShieldAnimations sheld;

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
            Debug.Log(ShieldInstance);
            if(ShieldInstance.GetComponent<ShieldAnimations>().ShieldIsPlaying)
            {


                x.GetComponent<MeleeGameBehavior>().HP -= 1;
                damageDelay = 2;
            }
        }
    }
    public void Attack() // Call this to activate the attack
    {
        
        ani.SetTrigger("RustedAttack");
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
