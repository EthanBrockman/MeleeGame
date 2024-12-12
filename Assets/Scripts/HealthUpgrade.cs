using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class HealthUpgrade : MonoBehaviour
{
    public MeleeGameBehavior GameManager;

    private int upgradeCost = 2;

    private int upgradeLevel = 1;

    public TMP_Text healthPriceText;

    // Start is called before the first frame update
    void Start()
    {
        healthPriceText.text += upgradeCost + " Coins";
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Player" && GameManager.Coins >= upgradeCost && upgradeLevel < 6)
        {
            GameManager.MaxHP += 1;
            GameManager.HP = GameManager.MaxHP;
            GameManager.Coins -= upgradeCost;
            upgradeLevel++;
            Debug.Log("HP Upgraded!");
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
            upgradeCost = 4;
        }
        if (upgradeLevel == 4)
        {
            upgradeCost = 5;
        }
        if (upgradeLevel == 5)
        {
            upgradeCost = 7;
        }
        healthPriceText.text = "Cost: " + upgradeCost + " Coins";
    }

}
