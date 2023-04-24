using System.Linq;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Transform parentEnemy;
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private AnimationCurve distanceMultiplier;
    [SerializeField] private Transform[] spawnPoints;

    private float minDistanceMultiplier = 5f;
    private float maxDistanceMultiplier = 25f;

    private float minTimerSpawn = 8f;
    private float maxTimerSpawn = 15f;

    private Player player;

    private float spawnTimer;

    private void Awake()
    {
        Transform[] childs = GetComponentsInChildren<Transform>();
        spawnPoints = childs.Where(child => child.tag == TagConstants.SPAWN_POINT).ToArray();
    }

    private void Start()
    {
        player = Player.Instance;
        WaitForNextSpawn();
    }

    private void Update()
    {
        float clampedPlayerDist = Mathf.Clamp((player.transform.position - transform.position).magnitude, minDistanceMultiplier, maxDistanceMultiplier);
        float relativeValue = 1 - (clampedPlayerDist - minDistanceMultiplier) / (maxDistanceMultiplier - minDistanceMultiplier);
        spawnTimer -= Time.deltaTime * (1f + distanceMultiplier.Evaluate(relativeValue));
        if (spawnTimer < 0f)
        {
            SpawnEnemy();
        }
    }

    private void WaitForNextSpawn()
    {
        spawnTimer = Random.Range(minTimerSpawn, maxTimerSpawn);
    }

    private void SpawnEnemy()
    {
        WaitForNextSpawn();
        GameObject enemy = Instantiate(enemyPrefab);
        enemy.transform.parent = parentEnemy;
        enemy.transform.position = spawnPoints[Random.Range(0, spawnPoints.Length)].position;
    }


}
