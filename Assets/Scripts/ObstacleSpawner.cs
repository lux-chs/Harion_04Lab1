using System.Collections;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [Header("Prefabs to Spawn")]
    public GameObject[] obstaclePrefabs;

    [Header("Spawn Intervals")]
    public float minSpawnDelay = 1.5f;
    public float maxSpawnDelay = 3.0f;

    void Start()
    {
        if (obstaclePrefabs == null || obstaclePrefabs.Length == 0)
        {
            Debug.LogError("ObstacleSpawner: No prefabs assigned in the Inspector!");
            return;
        }

        StartCoroutine(SpawnLoop());
    }

    IEnumerator SpawnLoop()
    {
        while (true)
        {
            // Pick a random delay between min and max
            float delay = Random.Range(minSpawnDelay, maxSpawnDelay);
            yield return new WaitForSeconds(delay);

            // Pick a random prefab from the array
            int randomIndex = Random.Range(0, obstaclePrefabs.Length);
            GameObject prefabToSpawn = obstaclePrefabs[randomIndex];

            if (prefabToSpawn != null)
            {
                Instantiate(prefabToSpawn, transform.position, Quaternion.identity);
            }
            else
            {
                Debug.LogWarning("ObstacleSpawner: One of the slots in obstaclePrefabs is empty/null!");
            }
        }
    }
}