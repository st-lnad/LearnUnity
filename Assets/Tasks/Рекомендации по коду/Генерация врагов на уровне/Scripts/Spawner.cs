using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField, Min(0.001f)] public float _spawnDelay;
    [SerializeField] private DirectMovement _enemyPrefab;
    [SerializeField] private List<SpawnPoint> _spawnPoints;

    private Coroutine _spawnLoop;

    private void Awake()
    {
        _spawnPoints = new List<SpawnPoint>();
    }
    private void Start()
    {
        _spawnLoop = StartCoroutine(Spawning());
    }
    private void OnDisable()
    {
        StopCoroutine(_spawnLoop);
    }
    private IEnumerator Spawning()
    {
        var delay = new WaitForSeconds(_spawnDelay);
        while (true)
        {
            if (_spawnPoints.Count == 0)
                continue;
            int index = Random.Range(0, _spawnPoints.Count);
            DirectMovement enemy = Instantiate(_enemyPrefab, _spawnPoints[index].transform.position,
                Quaternion.identity);
            enemy.SetDirection(new Vector3(Random.value, Random.value, Random.value));
            yield return delay;
        }
    }
    public void AddSpawnPoint(SpawnPoint point)
    {
        _spawnPoints.Add(point);
    }
    public void DeleteSpawnPoint(SpawnPoint point)
    {
        _spawnPoints.Remove(point);
    }
}
