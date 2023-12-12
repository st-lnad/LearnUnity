using UnityEngine;

public class AdvancedSpawnPoint : MonoBehaviour
{
    [SerializeField] private StalkerMovement _enemyPrefab;
    [SerializeField] private Transform _target;

    public StalkerMovement EnemyPrefab => _enemyPrefab;
    public Transform Target => _target;

    private AdvancedSpawner _spawner;
    private void Start()
    {
        _spawner = FindFirstObjectByType<AdvancedSpawner>(); 
        if (_spawner != null)
            _spawner.AddSpawnPoint(GetComponent<AdvancedSpawnPoint>());
    }
    private void OnDisable()
    {
        if (_spawner != null)
            _spawner.DeleteSpawnPoint(GetComponent<AdvancedSpawnPoint>());
    }
}
