using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Transform[] _spawnPoints;
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private float _spawnInterval = 2f;

    private int currentSpawnPointIndex = 0;

    private void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    private IEnumerator SpawnEnemies()
    {
        while (true)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(_spawnInterval);
        }
    }

    private void SpawnEnemy()
    {
        if (_spawnPoints.Length > 0)
        {
            GameObject enemy = Instantiate(enemyPrefab, _spawnPoints[currentSpawnPointIndex].position, Quaternion.identity);

            currentSpawnPointIndex = (currentSpawnPointIndex + 1) % _spawnPoints.Length;

        }
        else
        {
            Debug.LogWarning("No spawn points defined!");
            return;
        }
    }
}
