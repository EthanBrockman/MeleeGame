using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ShieldAnimations : MonoBehaviour
{
    Animator shi;
    void Start()
    {
        shi = GetComponent<Animator>();
    }



    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            Debug.Log("this should be working");
            shi.SetTrigger("ShieldHold");
            

        }
        else if (Input.GetKeyUp(KeyCode.K))
        {
            shi.SetTrigger("PutAway");
            
        }
    }
}
