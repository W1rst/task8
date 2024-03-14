using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletExp : MonoBehaviour
{
    private Transform _target;
    private float _speed = 7;
    [SerializeField] private float _explosionRadius = 3f;

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
            if (Vector3.Distance(transform.position, _target.position) < 0.3f)
            {
                Explode();
            }
            else
            {
                Vector3 dir = _target.position - transform.position;
                transform.Translate(dir.normalized * Time.deltaTime * _speed, Space.World);
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Explode()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, _explosionRadius);
        foreach (Collider collider in colliders)
        {
            if (collider.CompareTag("Enemy"))
            {
                collider.GetComponent<EnemyGoblin>().TakeDamage(25);
                Destroy(gameObject);
            }
        }
    }
}