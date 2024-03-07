using UnityEngine;

public class EnemyGoblin : MonoBehaviour
{
    [SerializeField] private int _maxHealth = 100;
    [SerializeField] private int _currentHealth;

    public static int enemy;

    private void Start()
    {
        _currentHealth = _maxHealth;
    }

    public void TakeDamage(int damageAmount)
    {
        _currentHealth -= damageAmount;

        if (_currentHealth <= 0)
        {
            Die();
            
            MainScript.instance.SetMoney(100);
        }
    }

    private void Die()
    {
        Destroy(gameObject);
        enemy++;
        Debug.Log(enemy);
    }
}
