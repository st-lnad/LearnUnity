using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdvancedSpawner : MonoBehaviour
{
    [SerializeField, Min(0.001f)] public float _spawnDelay;
    [SerializeField] private List<AdvancedSpawnPoint> _spawnPoints;

    private Coroutine _spawnLoop;

    private void Awake()
    {
        _spawnPoints = new List<AdvancedSpawnPoint>();
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
                yield return null;
            int index = Random.Range(0, _spawnPoints.Count);
            StalkerMovement enemy = Instantiate(_spawnPoints[index].EnemyPrefab,
                _spawnPoints[index].transform.position, Quaternion.identity);
            enemy.SetTarget(_spawnPoints[index].Target);
            yield return delay;
        }
    }

    public void AddSpawnPoint(AdvancedSpawnPoint point)
    {
        _spawnPoints.Add(point);
    }

    public void DeleteSpawnPoint(AdvancedSpawnPoint point)
    {
        _spawnPoints.Remove(point);
    }
}
