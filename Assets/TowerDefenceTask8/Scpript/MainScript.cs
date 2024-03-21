using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;
using static UnityEngine.GraphicsBuffer;
using UnityEditor;

public class MainScript : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textCoins;
    [SerializeField] private TextMeshProUGUI textTimer;
    [SerializeField] private TextMeshProUGUI textHP;

    [SerializeField] private int _money = 1100;
    [SerializeField] private int _hp = 20; 
    private int _maxHp = 20;
    private float _maxWinTime = 40f;

    [SerializeField] GameObject[] stars;
    [SerializeField] Button _back;
    [SerializeField] Button _backtolvl;
    [SerializeField] Button _backLose;
    public static MainScript instance;

    public int[] starsssss = new int[8];

    [SerializeField] private GameObject _losePanel;

    EnemySpawner enemySp;

    private float _timer;
    private int _activeStars;
    public static string starsCountKey = "ActiveStarsCount_";


    void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        _activeStars = stars.Length;
        _backLose.onClick.AddListener(BackToMenu);
        _backtolvl.onClick.AddListener(BackToMenu);
        _back.onClick.AddListener(BackToMenu);
        _timer = 0f;
    }

    private void Update()
    {
        _timer += Time.deltaTime;

        UpdateTimerText();

        //Win();
        Lose();
    }

    int GetCurrentLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int level = currentSceneIndex;
        if (level >= 2 && level <= 9)
        {
            return level - 2;
        }
        else
        {
            Debug.LogWarning("Current scene is not a level scene.");
            return -1;
        }
    }

    private void UpdateTimerText()
    {
        int minutes = Mathf.FloorToInt(_timer / 60f);
        int seconds = Mathf.FloorToInt(_timer % 60f);

        string timerString = string.Format("{0:00}:{1:00}", minutes, seconds);

        textTimer.text = "Time: " + timerString;
    }

    public void Win()
    {
        if (_timer > _maxWinTime || _hp != _maxHp)
        {
            if (_activeStars > 0)
            {
                stars[1].SetActive(false);
                _activeStars--;

                if (_hp < 20)
                {
                    stars[2].SetActive(false);
                    _activeStars--;
                }
            }
        }

        int currLvl = GetCurrentLevel();

        starsssss[currLvl] = _activeStars;

        string key = starsCountKey + currLvl.ToString();
        PlayerPrefs.SetInt(key, starsssss[currLvl]);

        PlayerPrefs.Save();
    }

    public int GetMoney()
    {
        return _money;
    }

    public void SetMoney(int money)
    {
        _money = money + _money;
        textCoins.text = _money.ToString();
    }

    public void DecreaseMoney(int amount)
    {
        _money -= amount;
        textCoins.text = _money.ToString();
    }

    public void DecreaseHP(int amount)
    {
        _hp -= amount;

        textHP.text = "HP: " + _hp.ToString();
    }

    void BackToMenu()
    {
        SceneManager.LoadScene(1);
        enemySp._winPanel.SetActive(false);
        _losePanel.SetActive(false);
        PlayerPrefs.Save();
        Time.timeScale = 1;

    }

    void Lose()
    {
        if (_hp <= 0)
        {
            _losePanel.SetActive(true);
        }
    }
}