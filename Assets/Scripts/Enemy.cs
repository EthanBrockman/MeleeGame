using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using Unity.VisualScripting;
using UnityEditor.Animations;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    
    public float health = 10;
    

    public void DamageCheck(float damage)
    {
        health -= damage;
        if (health < 0)
        {
            Destroy(gameObject);
        }
    }
}
    
    
        

      

