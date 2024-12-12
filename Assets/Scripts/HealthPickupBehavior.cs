using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickupBehavior : MonoBehaviour
{
    public MeleeGameBehavior GameManager;

    // Start is called before the first frame update
    void Start()
    {
        GameManager = GameObject.Find("Game Manager").GetComponent<MeleeGameBehavior>();
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Player")
        {
            Destroy(this.transform.gameObject);
            Debug.Log("Health Pickup Collected! +3 Health");
            GameManager.MaxHP += 3;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

}
