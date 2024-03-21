using Dreamteck.Splines;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject _enemyPrefab;
    [SerializeField] private float _spawnRate = 2f;
    [SerializeField] private int _maxEnemies = 0;
    public GameObject _winPanel;

    [SerializeField] private SplineComputer _splineObject;

    private int _currentEnemies = 0;
    private float _spawnTimer = 0f;
    public static int _endEnemies = 0;

    private void Update()
    {
        if (_currentEnemies < _maxEnemies && _currentEnemies < 100)
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

        EnemyDestroyed();
    }

    void EnemyDestroyed()
    {
        if (EnemyGoblin.enemy >= 100)
        {
            _winPanel.SetActive(true);
            MainScript.instance.Win();
            EnemyGoblin.enemy = 0;
            Time.timeScale = 0;
        }
    }
}
