using Dreamteck.Splines;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject _enemyPrefab;
    [SerializeField] private float _spawnRate = 2f;
    [SerializeField] private int _maxEnemies = 10;

    [SerializeField] private SplineComputer _splineObject;

    private int _currentEnemies = 0;
    private float _spawnTimer = 0f;

    private void Update()
    {
        if (_currentEnemies < _maxEnemies)
        {
            _spawnTimer += Time.deltaTime;

            if (_spawnTimer >= _spawnRate)
            {
                _spawnTimer = 0f;

                GameObject newEnemy = Instantiate(_enemyPrefab, transform.position, Quaternion.identity);
                SplineFollower follower = newEnemy.GetComponent<SplineFollower>();
                follower.spline = _splineObject;

                _currentEnemies++;
            }
        }
    }

    public void EnemyDestroyed()
    {
        _currentEnemies--;
    }
}
