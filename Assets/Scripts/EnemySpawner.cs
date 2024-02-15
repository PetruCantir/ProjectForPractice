using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private Transform _player;

    private const int MaxEnemies = 4;

    private void Start()
    {
        StartCoroutine(EnemyDrop());
    }

    IEnumerator EnemyDrop()
    {
        while (true)
        {
            yield return new WaitForSeconds(3.3f);

            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
            if (enemies.Length < MaxEnemies)
            {
                SpawnEnemy();
            }
        }
    }

    private void SpawnEnemy()
    {
        Vector3 spawnPosition = GetRandomSpawnPosition();
        GameObject enemyInstance = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
        Enemy enemyScript = enemyInstance.GetComponent<Enemy>();

        if (enemyScript != null)
        {
            enemyScript._player = _player;
        }
    }

    private Vector3 GetRandomSpawnPosition()
    {
        int xPos = Random.Range(2, 50);
        int zPos = Random.Range(2, 40);
        return new Vector3(xPos, 3, zPos);
    }
}
