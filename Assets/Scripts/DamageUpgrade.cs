using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class DamageUpgrade : MonoBehaviour
{
    public MeleeGameBehavior GameManager;

    private int upgradeCost = 2;

    private int upgradeLevel = 1;

    //public TMP_Text HealthText;
    public TMP_Text dmgPriceText;

    // Start is called before the first frame update
    void Start()
    {
        dmgPriceText.text += upgradeCost + " Coins";
    }
    void OnCollisionEnter(Collision collision)
    {
        //if (collision.gameObject.name == "Player" && GameManager.Coins >= upgradeCost && upgradeLevel < 6) // && GameManager.Coins >= upgradeCost
        if(collision.gameObject.name == "Player" && GameManager.Coins >= upgradeCost && upgradeLevel < 6)
        {
            GameManager.MaxDmg += 1;
            GameManager.Coins -= upgradeCost;
            upgradeLevel++;
            Debug.Log("Damage Upgraded!");
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (upgradeLevel == 2)
        {
            upgradeCost = 3;
        }
        if (upgradeLevel == 3)
        {
            upgradeCost = 5;
        }
        if (upgradeLevel == 4)
        {
            upgradeCost = 8;
        }
        if (upgradeLevel == 5)
        {
            upgradeCost = 10;
        }

        dmgPriceText.text = "Cost: " + upgradeCost + " Coins";
    }
    
}
