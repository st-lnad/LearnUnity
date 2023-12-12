using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    private Spawner _spawner;
    private void Start()
    {
        _spawner = FindFirstObjectByType<Spawner>(); 
        if (_spawner != null)
            _spawner.AddSpawnPoint(GetComponent<SpawnPoint>());
    }
    private void OnDisable()
    {
        if (_spawner != null)
            _spawner.DeleteSpawnPoint(GetComponent<SpawnPoint>());
    }
}
