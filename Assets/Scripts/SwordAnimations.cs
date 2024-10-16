using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;


public class SwordAnimations : MonoBehaviour
{
    public float DelayBetweenAttacks = 1; // Delay between attack animations
    private float DelayBetweenDamaged = 0; // Creates a delay between the animation dealing damage so that animations dont deal more than attack per animation
    private float attackDelay = 0; // delay but private
    private Animator ani;
    private bool attack = false; // Used for animation events along with its methods
    public bool AnimationChange = false;
    void TurnOnAttack()
    {
        attack = true;
    }
    void TurnOffAttack()
    {
        attack = false;
    }
    
    private void OnCollisionEnter(Collision col)
    {
        
        Enemy enemyScript;
        bool isEnemy = col.gameObject.TryGetComponent<Enemy>(out enemyScript);
        if (attack && isEnemy)
        {
            
            if (DelayBetweenDamaged > 0)
            {
                col.gameObject.GetComponent<Enemy>().DamageCheck(1);
            }
            Debug.Log(DelayBetweenDamaged);
            DelayBetweenDamaged = 0;
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
        
        if (Input.GetKey(KeyCode.J) && attackDelay <= 0)
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
                if (DelayBetweenDamaged <= 0)
                {
                    DelayBetweenDamaged = 1;
                }

        }
            
        
        

    }
    

}
