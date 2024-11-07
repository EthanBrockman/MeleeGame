// Ethan Brockman

using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ShieldAnimations : MonoBehaviour
{
    Animator shi;
    private bool shieldIsPlaying = false;
    
    
    void Start()
    {
        shi = GetComponent<Animator>();
        
    }

    public bool ShieldIsPlaying()
    {
        return shieldIsPlaying;
    }

    // Update is called once per frame
    void Update()
    {
        
            if (Input.GetKeyDown(KeyCode.K))
            {

                shi.SetTrigger("ShieldHold");
                shieldIsPlaying = false;

            }
            else if (Input.GetKeyUp(KeyCode.K))
            {
                shi.SetTrigger("PutAway");
                shieldIsPlaying = true;
            }
        
    }
}
