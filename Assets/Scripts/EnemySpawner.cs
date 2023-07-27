using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Transform[] _spawnPoints;
    [SerializeField] private Enemy enemyPrefab;
    [SerializeField] private float _spawnInterval = 2f;
    [SerializeField] private WaitForSeconds _spawnDelay;

    private int currentSpawnPointIndex = 0;

    private void Awake()
    {
        _spawnDelay = new WaitForSeconds(_spawnInterval);
    }
    private void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    private IEnumerator SpawnEnemies()
    {
        while (_spawnPoints.Length > 0)
        {
                SpawnEnemy();
                yield return _spawnDelay;
        }
    }

    private void SpawnEnemy()
    {
        var enemy = Instantiate(enemyPrefab, _spawnPoints[currentSpawnPointIndex].position, Quaternion.identity);
        currentSpawnPointIndex = (currentSpawnPointIndex + 1) % _spawnPoints.Length;
    }
}
