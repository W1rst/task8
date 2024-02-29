using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class MainScript : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textCoins;
    [SerializeField] private int _money = 1100;
    [SerializeField] private int _hp = 20;

    public static MainScript instance;

    private void Awake()
    {
        instance = this;
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
}
