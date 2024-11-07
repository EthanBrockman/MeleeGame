// Ethan Brockman

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarkAttack : MonoBehaviour
{
    private Animator ani;
    public void Attack() // Call this to activate the attack
    {
        ani.SetTrigger("DarkSwing");
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
