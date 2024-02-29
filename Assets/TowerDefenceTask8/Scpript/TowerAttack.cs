using UnityEngine;
using System.Collections.Generic;

public class TowerAttack : MonoBehaviour
{
    [SerializeField] private float _rotationSpeed = 5f;
    [SerializeField] private float _detectionRadius = 10f;
    [SerializeField] private float _attackCooldown = 2f;
    [SerializeField] private GameObject _projectilePrefab;
    [SerializeField] private Transform _projectileSpawnPoint;
    [SerializeField] private int _numberOfProjectiles = 3;

    private float _attackTimer = 0f;
    private Transform[] _targetEnemies;

    private void Start()
    {
        _targetEnemies = new Transform[_numberOfProjectiles];
    }

    private void Update()
    {
        SearchForTargets();
        RotateTower();

        _attackTimer -= Time.deltaTime;
        if (_attackTimer <= 0f)
        {
            Attack();
            _attackTimer = _attackCooldown;
        }
    }

    private void SearchForTargets()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, _detectionRadius);
        List<Transform> enemyTransforms = new List<Transform>();
        foreach (Collider collider in colliders)
        {
            if (collider.CompareTag("Enemy"))
            {
                enemyTransforms.Add(collider.transform);
            }
        }

        for (int i = 0; i < _numberOfProjectiles; i++)
        {
            if (enemyTransforms.Count > 0)
            {
                int randomIndex = Random.Range(0, enemyTransforms.Count);
                _targetEnemies[i] = enemyTransforms[randomIndex];
                enemyTransforms.RemoveAt(randomIndex);
            }
            else
            {
                _targetEnemies[i] = null;
            }
        }
    }

    private void RotateTower()
    {
        if (_targetEnemies[0] != null)
        {
            Vector3 direction = _targetEnemies[0].position - transform.position;
            Quaternion lookRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, _rotationSpeed * Time.deltaTime);
        }
    }

    private void Attack()
    {
        for (int i = 0; i < _numberOfProjectiles; i++)
        {
            if (_targetEnemies[i] != null)
            {
                GameObject projectile = Instantiate(_projectilePrefab, _projectileSpawnPoint.position, Quaternion.identity);
                Vector3 direction = (_targetEnemies[i].position - transform.position).normalized;
                projectile.GetComponent<Rigidbody>().velocity = direction * 14;
            }
        }
    }
}
