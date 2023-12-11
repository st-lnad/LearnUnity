using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField, Min(0.001f)] public float _spawnDelay;
    [SerializeField] private GameObject _enemyPrefab;
    public static Spawner Instance;

    private List<SpawnPoint> _spawnPoints;
    private Coroutine _spawnLoop;

    public IEnumerator SpawnLoop()
    {
        while (true)
        {
            if (_spawnPoints.Count == 0)
                continue;

            int index = (int)Random.Range(0, _spawnPoints.Count - 0.01f);
            DirectMovement enemy = Instantiate(_enemyPrefab, _spawnPoints[index].transform.position,
                Quaternion.identity).GetComponent<DirectMovement>();
            enemy.SetDirection(new Vector3(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f)));

            yield return new WaitForSeconds(_spawnDelay);
        }
        yield return null;
    }
    private void Awake()
    {
        _spawnPoints = new List<SpawnPoint>();
        Instance = GetComponent<Spawner>();
    }
    private void Start()
    {
        _spawnLoop = StartCoroutine(SpawnLoop());
    }
    private void OnDisable()
    {
        StopCoroutine(_spawnLoop);
    }
    public void AddSpawnPoint(SpawnPoint spawnPoint)
    {
        _spawnPoints.Add(spawnPoint);
    }
    public void DeleteSpawnPoint(SpawnPoint spawnPoint)
    {
        _spawnPoints.Remove(spawnPoint);
    }

}
