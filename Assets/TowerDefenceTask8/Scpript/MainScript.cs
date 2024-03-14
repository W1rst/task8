using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainScript : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textCoins;
    [SerializeField] private TextMeshProUGUI textTimer;
    [SerializeField] private TextMeshProUGUI textHP;

    [SerializeField] private int _money = 1100;
    [SerializeField] private int _hp = 20;
    [SerializeField] GameObject[] cups;
    [SerializeField] Button _back;
    [SerializeField] Button _backtolvl;
    [SerializeField] Button _backLose;
    public static MainScript instance;

    [SerializeField] private GameObject _losePanel;

    EnemySpawner enemySp;

    private float _timer;
    private int _activeCups;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        _backLose.onClick.AddListener(BackToMenu);
        _backtolvl.onClick.AddListener(BackToMenu);
        _back.onClick.AddListener(BackToMenu);
        _timer = 0f;
        _activeCups = cups.Length;
    }

    private void Update()
    {
        _timer += Time.deltaTime;

        UpdateTimerText();

        if (_timer <= 120f || _hp != 20)
        {
            if (_activeCups > 0)
            {
                _activeCups--;
                cups[2].SetActive(false);
                if (_hp < 20)
                {
                    cups[1].SetActive(false);
                }
            }
        }
        Lose();
    }

    private void UpdateTimerText()
    {
        int minutes = Mathf.FloorToInt(_timer / 60f);
        int seconds = Mathf.FloorToInt(_timer % 60f);

        string timerString = string.Format("{0:00}:{1:00}", minutes, seconds);

        textTimer.text = "Time: " + timerString;
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
    }

    void Lose()
    {
        if(_hp <= 0)
        {
            _losePanel.SetActive(true);
        }
    }
}
