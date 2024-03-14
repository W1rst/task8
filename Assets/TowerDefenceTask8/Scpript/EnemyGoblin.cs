using UnityEngine;
using UnityEngine.UI;

public class EnemyGoblin : MonoBehaviour
{
    [SerializeField] private int _maxHealth = 100;
    private int _currentHealth;

    public static int enemy;

    [SerializeField] private Slider healthSlider;

    private void Start()
    {
        _currentHealth = _maxHealth;

        healthSlider.maxValue = _maxHealth;
        healthSlider.value = _currentHealth;
        
    }

    public void TakeDamage(int damageAmount)
    {
        _currentHealth -= damageAmount;

        if (healthSlider != null)
        {
            healthSlider.value = _currentHealth;
        }

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
