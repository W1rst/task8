using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            EnemyGoblin enemyScript = other.GetComponent<EnemyGoblin>();

            if (enemyScript != null)
            {
                enemyScript.TakeDamage(25);
            }

            Destroy(gameObject);
        }
    }
}
