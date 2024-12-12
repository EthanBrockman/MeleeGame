using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public MeleeGameBehavior GameManager;

    public GameObject Coin;

    public GameObject HPDrop;

    public float health = 10;

    private bool isDestroyed = false;

    private bool enemyCounted = false;

    private int hpDrop;

    private bool lootDropped = false;

    private Vector3 enemyPosition = new Vector3();

    private Quaternion coinRotation = new Quaternion(90, 0, 90, 1);
    private Quaternion hpRotation = new Quaternion(90, 0, 0, 1);

    void Start()
    {
        GameManager = GameObject.Find("Game Manager").GetComponent<MeleeGameBehavior>();
        Coin = GameObject.Find("GoldCoin");
        HPDrop = GameObject.Find("Health Pickup");
        GameManager.EnemyCount++;
        enemyCounted = true;
    }
    public void DamageCheck(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            enemyPosition = this.transform.position;

            Destroy(gameObject);

            isDestroyed = true;

        }
    }

    public void OnDestroy()
    {
        if (isDestroyed == true)
        {
            if(lootDropped == false)
            {
                lootDropped = true;

                GameManager.EnemyCount--;

                hpDrop = UnityEngine.Random.Range(0, 3);

                GameObject newCoin = Instantiate(Coin, enemyPosition, coinRotation);

                Debug.Log("Coin Dropped!");

                if (hpDrop == 1)
                {
                    GameObject newHealthPickup = Instantiate(HPDrop, enemyPosition, hpRotation);
                    Debug.Log("Health Pickup Dropped!");
                }

                GameManager.KillCount++;
            }
        }
    }

    public void Update()
    {
        if (!enemyCounted)
        {
            enemyCounted = true;
            GameManager.EnemyCount++;
        }
    }
}
        

      

