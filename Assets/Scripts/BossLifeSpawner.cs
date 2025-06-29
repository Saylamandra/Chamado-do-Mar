using UnityEngine;

public class BossLifeSpawner : MonoBehaviour
{
    public GameObject lifePrefab; // Prefab de vida
    public Transform[] spawnPoints; // Pontos onde a vida pode nascer

    public int hitsToSpawnLife = 20; // A cada 20 hits spawna vida
    private int currentHits = 0;

    public void RegisterHit()
    {
        currentHits++;

        if (currentHits >= hitsToSpawnLife)
        {
            SpawnLife();
            currentHits = 0; // Reseta o contador
        }
    }

    void SpawnLife()
    {
        int randomIndex = Random.Range(0, spawnPoints.Length);
        Transform spawnPoint = spawnPoints[randomIndex];
        Instantiate(lifePrefab, spawnPoint.position, Quaternion.identity);
    }
}
