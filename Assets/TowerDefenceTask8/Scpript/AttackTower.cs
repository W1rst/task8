using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.ProBuilder;

public class AttackTower : MonoBehaviour
{
    [SerializeField] private GameObject _bullet;
    [SerializeField] private GameObject _bulletExp;
    [SerializeField] private float _currCooldown;
    [SerializeField] private float _cooldown;
    [SerializeField] private int _numberOfProjectiles;
    
    private float _range = 6;
    Transform _target;
    private void Update()
    {
        if (CanShoot())
        {
            SearchTarget();
        }

        if (_currCooldown > 0)
        {
            _currCooldown -= Time.deltaTime;
        }

        RotateTowards(_target.position);
    }

    bool CanShoot()
    {
        return _currCooldown <= 0;
    }

    void SearchTarget()
    {
        _target = null;
        float nearestEnemyDistance = Mathf.Infinity;

        foreach (GameObject enemy in GameObject.FindGameObjectsWithTag("Enemy"))
        {
            float currDistance = Vector3.Distance(transform.position, enemy.transform.position);

            if (currDistance < nearestEnemyDistance && currDistance <= _range)
            {
                _target = enemy.transform;
                nearestEnemyDistance = currDistance;
            }
        }

        if (_target != null)
        {
            RotateTowards(_target.position);
            if(_numberOfProjectiles == 1) 
            {
                Shoot(_target);
            } else if (_numberOfProjectiles == 2)
            {
                ShootExp(_target);
            }
        }
    }

    void RotateTowards(Vector3 targetPosition)
    {
        Vector3 direction = targetPosition - transform.position;
        direction.y = 0;
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, 5 * Time.deltaTime);
    }

    void Shoot(Transform enemy)
    {
        _currCooldown = _cooldown;
        GameObject proj = Instantiate(_bullet);
        proj.transform.position = transform.position;
        proj.GetComponent<Bullet>().SetTarget(enemy);
    } 
    
    void ShootExp(Transform enemy)
    {
        _currCooldown = _cooldown;
        GameObject proj = Instantiate(_bulletExp);
        proj.transform.position = transform.position;
        proj.GetComponent<BulletExp>().SetTarget(enemy);
    }
}
