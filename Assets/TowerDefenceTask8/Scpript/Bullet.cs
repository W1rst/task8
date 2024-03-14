using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Transform _target;
    private float _speed = 7;

    void Update()
    {
        Move();
    }

    public void SetTarget(Transform enemy)
    {
        _target = enemy;
    }

    private void Move()
    {
        if (_target != null)
        {
            Vector3 dir = _target.position - transform.position;
            transform.Translate(dir.normalized * Time.deltaTime * _speed, Space.World);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            Destroy(gameObject);
            other.GetComponent<EnemyGoblin>().TakeDamage(25);
        }
    }
}
