using UnityEngine;
using System.Collections;

public class ObsticalSpawner : MonoBehaviour
{
    [SerializeField] private GameObject obstaclePrefab;
    [SerializeField] private float spawnInterval = 2f;
    [SerializeField] private float obstacleSpeed = 1f;
    [SerializeField] private Transform startPoint;
    [SerializeField] private Transform endPoint;
    [SerializeField] private Transform topStartPoint; // New top start point
    [SerializeField] private Transform topEndPoint; // New top end point
    [SerializeField] private float spawnDelay = 2f; // Delay before spawning starts again
    private float _timeSinceLastSpawn;
    private float _timeElapsed;
    private bool _isSpawning = true;

    public float ObstacleSpeed => obstacleSpeed;

    private void Start()
    {
        StartCoroutine(StartSpawningWithDelay());
    }

    void Update()
    {
        if (!_isSpawning) return;

        _timeSinceLastSpawn += Time.deltaTime;
        _timeElapsed += Time.deltaTime;

        if (_timeSinceLastSpawn >= spawnInterval)
        {
            SpawnObstacle();
            _timeSinceLastSpawn = 0f;
        }

        // Increase obstacle speed over time
        obstacleSpeed = 1f + (_timeElapsed / 10f);
    }

    private void SpawnObstacle()
    {
        // Randomly choose between bottom and top spawn points
        bool spawnAtTop = Random.value > 0.5f;
        Transform chosenStartPoint = spawnAtTop ? topStartPoint : startPoint;
        Transform chosenEndPoint = spawnAtTop ? topEndPoint : endPoint;

        GameObject obstacle = Instantiate(obstaclePrefab, chosenStartPoint.position, Quaternion.identity);
        obstacle.AddComponent<Obstacle>().Initialize(chosenStartPoint.position, chosenEndPoint.position, obstacleSpeed);
    }

    public void ResetElapsedTime()
    {
        _timeElapsed = 0f;
    }

    public void StopSpawningForAWhile()
    {
        StartCoroutine(StopSpawningCoroutine());
    }

    private IEnumerator StopSpawningCoroutine()
    {
        _isSpawning = false;
        yield return new WaitForSeconds(spawnDelay);
        _isSpawning = true;
    }

    private IEnumerator StartSpawningWithDelay()
    {
        _isSpawning = false;
        yield return new WaitForSeconds(spawnDelay);
        _isSpawning = true;
    }
}