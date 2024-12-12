using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class MeleeGameBehavior : MonoBehaviour
{
    private int _coinsCollected = 0;

    private int _playerHP = 10;

    private int _maxHP = 10;

    private int _dmg = 1;

    private int _wave = 0;

    private int _enemyCount = 0;

    private int _killCount = 0;

    private bool waveChanged = false;

    private Vector3 enemySpawn1 = new Vector3(-37.6988754f, 1.000000f, 33.2463913f);
    private Vector3 enemySpawn2 = new Vector3(22.7776318f, 1.000000f, 42.7858047f);
    private Vector3 enemySpawn3 = new Vector3(-50.8132706f, 1.4799999f, 12.0569477f);
    private Vector3 enemySpawn4 = new Vector3(56.0710602f, 1.4799999f, 11.5811357f);

    private Quaternion enemyRotation = new Quaternion(0, 0, 0, 1);

    public GameObject SilverWarrior;
    public GameObject RustedWarrior;
    public GameObject DarkWarrior;

    public GameObject Player;

    public TMP_Text HealthText;
    public TMP_Text CoinsText;
    public TMP_Text WaveText;
    public TMP_Text EnemiesText;
    public TMP_Text DeathText;

    public UnityEngine.UI.Button RetryButton;

    public int EnemyCount
    {
        get { return _enemyCount; }
        set
        {
            _enemyCount = value;
            if (_enemyCount < 0)
            {
                _enemyCount = 0;
            }
            EnemiesText.text = "Enemies Remaining: " + EnemyCount;
        }
    }

    public int KillCount
    {
        get { return _killCount; }
        set
        {
            _killCount = value;
        }
    }

    public int Coins
    {
        get
        {
            return _coinsCollected;
        }
        set
        {
            _coinsCollected = value;
            CoinsText.text = "Coins: " + Coins;
        }
    }

    public void RestartScene()
    {
        Debug.Log("Restarting");

        //SceneManager.LoadScene("MainScene");

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        Time.timeScale = 1f;
    }

    public int MaxHP
    {
        get { return _maxHP; }
        set
        {
            _maxHP = value;
        }
    }

    public int MaxDmg
    {
        get { return _dmg; }
        set { _dmg = value; }
    }

    public int HP
    {
        get { return _playerHP; }

        set
        {
            _playerHP = value;

            if (_playerHP > MaxHP)
            {
                _playerHP = MaxHP;
            }
        
            if(_playerHP <= 0)
            {
                //Destroy(Player);

                DeathText.text = "YOU DIED! You slayed " + KillCount + " enemies!";

                PlayerBehavior.GameComplete();

                RetryButton.gameObject.SetActive(true);
            }

            HealthText.text = "Health: " + HP;
        }
    }

    public int Wave
    {
        get { return _wave; }
        set
        {
            _wave = value;
            WaveText.text = "Wave " + Wave;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        _enemyCount = _enemyCount - 3;
        CoinsText.text = "Coins: " + Coins;
        HealthText.text = "Health: " + HP;
        WaveText.text = "Wave " + Wave;
        EnemiesText.text = "Enemies Remaining: " + EnemyCount;

        SilverWarrior = GameObject.Find("SilverWarrior");
        RustedWarrior = GameObject.Find("RustedWarrior");
        DarkWarrior = GameObject.Find("DarkWarrior");

        Player = GameObject.Find("Player");

        WaveStart(1);
    }

    void WaveStart(int wave) //spawn enemies(int wave)
    {
        if (wave == 1)
        {
            //intendedEnemyCount = 2;
            GameObject w1Enemy1 = Instantiate(RustedWarrior, enemySpawn3, enemyRotation);
            GameObject w1Enemy2 = Instantiate(RustedWarrior, enemySpawn4, enemyRotation);
        }
        if (wave == 2)
        {
            // intendedEnemyCount = 3;
            GameObject w2Enemy1 = Instantiate(RustedWarrior, enemySpawn1, enemyRotation);
            GameObject w2Enemy2 = Instantiate(RustedWarrior, enemySpawn2, enemyRotation);
            GameObject w2Enemy3 = Instantiate(SilverWarrior, enemySpawn3, enemyRotation);

        }
        if (wave == 3)
        {
            //intendedEnemyCount = 5;
            GameObject w3Enemy1 = Instantiate(RustedWarrior, enemySpawn1, enemyRotation);
            GameObject w3Enemy2 = Instantiate(RustedWarrior, enemySpawn2, enemyRotation);
            GameObject w3Enemy3 = Instantiate(RustedWarrior, enemySpawn3, enemyRotation);
            GameObject w3Enemy4 = Instantiate(SilverWarrior, enemySpawn4, enemyRotation);
            GameObject w3Enemy5 = Instantiate(SilverWarrior, enemySpawn1, enemyRotation);
        }
        if (wave == 4)
        {
            // intendedEnemyCount = 7;
            GameObject w4Enemy1 = Instantiate(RustedWarrior, enemySpawn1, enemyRotation);
            GameObject w4Enemy2 = Instantiate(RustedWarrior, enemySpawn2, enemyRotation);
            GameObject w4Enemy3 = Instantiate(RustedWarrior, enemySpawn3, enemyRotation);
            GameObject w4Enemy4 = Instantiate(SilverWarrior, enemySpawn4, enemyRotation);
            GameObject w4Enemy5 = Instantiate(SilverWarrior, enemySpawn1, enemyRotation);
            GameObject w4Enemy6 = Instantiate(SilverWarrior, enemySpawn2, enemyRotation);
            GameObject w4Enemy7 = Instantiate(DarkWarrior, enemySpawn3, enemyRotation);
        }

        if (wave >= 5)
        {
            GameObject w5Enemy1 = Instantiate(RustedWarrior, enemySpawn1, enemyRotation);
            GameObject w5Enemy2 = Instantiate(RustedWarrior, enemySpawn2, enemyRotation);
            GameObject w5Enemy3 = Instantiate(RustedWarrior, enemySpawn3, enemyRotation);
            GameObject w5Enemy4 = Instantiate(RustedWarrior, enemySpawn4, enemyRotation);
            GameObject w5Enemy5 = Instantiate(SilverWarrior, enemySpawn1, enemyRotation);
            GameObject w5Enemy6 = Instantiate(SilverWarrior, enemySpawn2, enemyRotation);
            GameObject w5Enemy7 = Instantiate(SilverWarrior, enemySpawn3, enemyRotation);
            GameObject w5Enemy8 = Instantiate(DarkWarrior, enemySpawn4, enemyRotation);
            GameObject w5Enemy9 = Instantiate(DarkWarrior, enemySpawn1, enemyRotation);
            GameObject w5Enemy10 = Instantiate(DarkWarrior, enemySpawn2, enemyRotation);
            // intendedEnemyCount = 10;
        }
    

        Wave++;
        Debug.Log($"Wave {Wave} starting!");
        waveChanged = false;
    }

    // Update is called once per frame
    void Update()
    {
        CoinsText.text = "Coins: " + Coins;
        HealthText.text = "Health: " + HP;
        WaveText.text = "Wave " + Wave;
        EnemiesText.text = "Enemies Remaining: " + EnemyCount;

        if (EnemyCount == 0)//wave change
        {
            Debug.Log("Wave Finished");
            if (waveChanged == false)
            {
                WaveStart(Wave + 1);
                waveChanged = true;
            }
        }
    }
}
