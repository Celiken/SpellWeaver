using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Transform parentEnemy;
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private float spawnTimerMin = 5f;
    [SerializeField] private float spawnTimerMax = 10f;
    [SerializeField] private Transform[] spawnPoints;

    private float spawnTimer;

    private void Awake()
    {
        Transform[] childs = GetComponentsInChildren<Transform>();
        spawnPoints = childs.Where(child => child.tag == TagConstants.SPAWN_POINT).ToArray();
    }

    private void Start()
    {
        spawnTimer = Random.Range(1, spawnTimerMax);
    }

    private void Update()
    {
        spawnTimer -= Time.deltaTime;
        if (spawnTimer < 0f)
        {
            SpawnEnemy();
        }
    }

    private void WaitForNextSpawn()
    {
        spawnTimer = Random.Range(spawnTimerMin, spawnTimerMax);
    }

    private void SpawnEnemy()
    {
        WaitForNextSpawn();
        GameObject enemy = Instantiate(enemyPrefab);
        enemy.transform.parent = parentEnemy;
        enemy.transform.position = spawnPoints[Random.Range(0, spawnPoints.Length)].position;
    }


}
