// Ethan Brockman

using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;


public class SwordAnimations : MonoBehaviour
{
    public float DelayBetweenAttacks = 1; // Delay between attack animations
    private double delayBetweenDamaged = 0; // Creates a delay between the animation dealing damage so that animations dont deal more than attack per animation
    public double damagedDelay = 0.8;
    private float attackDelay = 0; // delay but private
    private Animator ani;
    public bool attack = false; // Used for animation events along with its methods
    public bool AnimationChange = false;
    [SerializeField] ShieldAnimations sheld;
     
    void TurnOnAttack()
    {
        attack = true;
        
    }
    
    void TurnOffAttack()
    {
        attack = false;
    }
    public double DelayBetweendamaged
    {
        get { return delayBetweenDamaged; }
        set { delayBetweenDamaged = value; }
    }
    public bool Attack()
    {
     
        return attack;
    }
    private void OnCollisionEnter(Collision collision)
    {
        
        Enemy enemyScript;
        bool isEnemy = collision.gameObject.TryGetComponent<Enemy>(out enemyScript);
        

        if (Attack() && isEnemy)
        {
            
            if (DelayBetweendamaged <= 0)
            {
                collision.gameObject.GetComponent<Enemy>().DamageCheck(1);
                Debug.Log("the enemy was damaged 1");
                DelayBetweendamaged = damagedDelay;
            }
            
        }
    }




    // Start is called before the first frame update
    void Start()
    {
        ani = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        attackDelay -= Time.deltaTime;
        DelayBetweendamaged -= Time.deltaTime;
        if (Input.GetKey(KeyCode.J) && attackDelay <= 0 && this.sheld.ShieldIsPlaying)
        {
            
            if (AnimationChange)
            {
                ani.SetTrigger("Attack1");
                AnimationChange = false;

            }
            else
            {
                ani.SetTrigger("Attack2");
                AnimationChange = true;
            }



            Debug.Log("Player attacks");
            attackDelay = DelayBetweenAttacks;
               
        }
            
        
        

    }
    

}
