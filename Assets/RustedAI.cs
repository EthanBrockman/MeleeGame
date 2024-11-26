using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class RustedAI : MonoBehaviour
{
    [SerializeField] RustedAttack instance;
    [SerializeField] GameObject play;
    Transform player;
    protected NavMeshAgent enemy;
    private void Start()
    {
        instance = GetComponent<RustedAttack>(); 
        play = GameObject.Find("Player");
        enemy = GetComponent<NavMeshAgent>();
        player = play.transform;
    }
    private void Update()
    {
        float distance = Vector3.Distance(player.transform.position, this.gameObject.transform.position);
        enemy.SetDestination(player.position);
        if (distance < 3)
        {
            instance.Attack();
        }
    }
}
