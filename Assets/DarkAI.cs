using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DarkAI : MonoBehaviour
{
    [SerializeField] DarkAttack instance;
    [SerializeField] GameObject play;
    Transform player;
    protected NavMeshAgent enemy;

    private void Start()
    {
        play = GameObject.Find("Player");
        enemy = GetComponent<NavMeshAgent>();
        player = play.transform;
        instance = GetComponent<DarkAttack>();
    }
    private void Update()
    {
        float distance = Vector3.Distance(player.transform.position, gameObject.transform.position);
        enemy.SetDestination(player.position);
        if (distance < 3)
        {
            instance.Attack();
        }
    }
}
