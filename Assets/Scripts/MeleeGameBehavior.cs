using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class MeleeGameBehavior : MonoBehaviour
{
    private int _coinsCollected = 0;

    private int _playerHP = 10;

    public TMP_Text HealthText;
    public TMP_Text CoinsText;

    public int Coins
    {
        get
        {
            return _coinsCollected;
        }
        set
        {
            _coinsCollected = value;
            CoinsText.text = "Coins" + Coins;
        }
    }

    public void RestartScene()
    {
        SceneManager.LoadScene(0);

        Time.timeScale = 1f;
    }

    public int HP
    {
        get { return _playerHP;  }

        set
        {
            _playerHP = value;

            HealthText.text = "Health: " + HP;
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        CoinsText.text += _coinsCollected;
        HealthText.text += _playerHP;
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
