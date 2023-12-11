using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    private void Start()
    {
        if (Spawner.Instance == null)
        {
            Debug.Log("Fuck");
        }
        Spawner.Instance.AddSpawnPoint(GetComponent<SpawnPoint>());
    }
    private void OnDisable()
    {
        Spawner.Instance.DeleteSpawnPoint(GetComponent<SpawnPoint>());
    }
}
