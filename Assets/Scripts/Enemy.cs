using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    float health = 3;

    private void Awake()
    {
        Destroy(gameObject, health);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Sword")
        {
            health -= 1;
            if (health < 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
