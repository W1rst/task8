using UnityEngine;
using UnityEngine.UI;

public class CreateTower : MonoBehaviour
{
    [SerializeField] private GameObject _towerOnePrefab;
    [SerializeField] private GameObject _towerTwoPrefab;
    [SerializeField] private GameObject _towerPanel;
    [SerializeField] private int _towerCostOne = 100;
    [SerializeField] private int _towerCostTwo = 200;

    [HideInInspector] public bool _canBuyTower = false;

    [SerializeField] private Button _towerOneButton;
    [SerializeField] private Button _towerTwoButton;
    [SerializeField] private Button _sellButton;
    [SerializeField] private Button _closeButton;

    private Vector3 _cubePosition;

    private void Start()
    {
        _towerPanel.SetActive(false);
        _towerOneButton.onClick.AddListener(BuyTowerOne);
        _towerTwoButton.onClick.AddListener(BuyTowerTwo);
        _sellButton.onClick.AddListener(SellTower);
        _closeButton.onClick.AddListener(CloseTowerPanel);
    }

    private void Update()
    {
        if (_canBuyTower)
        {
            ShowTowerPanel(_cubePosition);
        } else
        {
            _towerPanel.SetActive(false);
        }
    }

    public void ShowTowerPanel(Vector3 cubePos)
    {
        _canBuyTower = true;
        _towerPanel.SetActive(true);
        _cubePosition = cubePos;
    }

    private void CloseTowerPanel()
    {
        _canBuyTower = false;
        _towerPanel.SetActive(false);
    }

    private void BuyTowerOne()
    {
        Collider[] colliders = Physics.OverlapSphere(_cubePosition + new Vector3(0f, 1f, 0f), 0.5f);

        if (colliders.Length > 0)
        {
            foreach (Collider col in colliders)
            {
                if (col.CompareTag("Tower"))
                {
                    return;
                }
            }
        }

        if (MainScript.instance.GetMoney() >= _towerCostOne)
        {
            MainScript.instance.DecreaseMoney(_towerCostOne);
            Instantiate(_towerOnePrefab, _cubePosition + new Vector3(0f, 1f, 0f), transform.rotation);
            CloseTowerPanel();
        }
    }

    private void BuyTowerTwo()
    {
        Collider[] colliders = Physics.OverlapSphere(_cubePosition + new Vector3(0f, 1f, 0f), 0.5f);

        if (colliders.Length > 0)
        {
            foreach (Collider col in colliders)
            {
                if (col.CompareTag("Tower"))
                {
                    return;
                }
            }
        }

        if (MainScript.instance.GetMoney() >= _towerCostTwo)
        {
            MainScript.instance.DecreaseMoney(_towerCostTwo);
            Instantiate(_towerTwoPrefab, _cubePosition + new Vector3(0f, 1f, 0f), transform.rotation);
            CloseTowerPanel();
        }
    }

    private void SellTower()
    {
        Collider[] colliders = Physics.OverlapSphere(_cubePosition + new Vector3(0f, 1f, 0f), 0.5f);

        if (colliders.Length > 0)
        {
            foreach (Collider col in colliders)
            {
                if (col.CompareTag("Tower"))
                {
                    MainScript.instance.SetMoney(100 / 2);
                    Destroy(col.gameObject);
                    return;
                }
            }
        }
    }
}
