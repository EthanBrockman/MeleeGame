using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SilverAI : MonoBehaviour
{
    float chargeTime = 10;
    float ChargeTimeUpdate = 0;
    float attackDelay = 7;
    float attackDelayUpdate = 0;
    bool IsAttack = false;
    

    [SerializeField] SilverAttack instance;
    [SerializeField] GameObject play;
    Transform player;
    protected NavMeshAgent enemy;
    private void Start()
    {
        instance = GetComponent<SilverAttack>();
        play = GameObject.Find("Player");
        enemy = GetComponent<NavMeshAgent>();
        player = play.transform;
    }
    private void Update()
    {
        bool x = instance.GetState();
        
        float distance = Vector3.Distance(player.transform.position, this.gameObject.transform.position);
        enemy.SetDestination(player.position);
        if (distance < 5 && attackDelayUpdate <= 0)
        {
            attackDelayUpdate = attackDelay;
            IsAttack = true;
            instance.Attack();
            Vector3 chargePoint = gameObject.transform.position + transform.forward * 15;
            if (x)
            {
                
                this.gameObject.GetComponent<NavMeshAgent>().destination = chargePoint;
                ChargeTimeUpdate -= Time.deltaTime;
                Debug.Log(attackDelayUpdate);
            }
            
        }
        ChargeTimeUpdate = chargeTime;

        Debug.Log(attackDelayUpdate);

        IsAttack = false;
        if (x == false)
        {
            this.gameObject.GetComponent<NavMeshAgent>().speed = 3;
        }
        else
        {
            this.gameObject.GetComponent<NavMeshAgent>().speed = 10;
        }
        attackDelayUpdate -= Time.deltaTime;
        

    }
}
