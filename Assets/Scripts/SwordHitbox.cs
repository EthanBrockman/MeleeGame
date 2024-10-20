using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordHitbox : MonoBehaviour
{
    SwordAnimations swor;
    
    // Start is called before the first frame update
    void Awake()
    {
        swor = GetComponent<SwordAnimations>();
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        
        Enemy enemyScript;
        bool isEnemy = collision.gameObject.TryGetComponent<Enemy>(out enemyScript);
        

        if (!swor.Attack() || !isEnemy)
        {
            return;
        }
        
        if (swor.DelayBetweendamaged > 0)
        {
            collision.gameObject.GetComponent<Enemy>().DamageCheck(1);
        }
        Debug.Log(swor.DelayBetweendamaged);
        swor.DelayBetweendamaged = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
