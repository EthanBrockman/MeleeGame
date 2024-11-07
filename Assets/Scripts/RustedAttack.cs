// Ethan Brockman

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RustedAttack : MonoBehaviour
{
    Animator ani;
    public void Attack() // Call this to activate the attack
    {
        ani.SetTrigger("RustedAttack");
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
