using UnityEngine;

public class LifeSpawner : MonoBehaviour
{
    public GameObject lifePrefab; // Prefab do item de vida
    public Transform[] spawnPoints; // Agora visível no Inspector
    private int nextSpawnScore = 100;

    void Update()
    {
        if (ScoreManager.Instance != null && ScoreManager.Instance.GetScore() >= nextSpawnScore)
        {
            SpawnLife();
            nextSpawnScore += 100; // próxima vida com 100 pontos a mais
        }
    }

    void SpawnLife()
    {
        int randomIndex = Random.Range(0, spawnPoints.Length);
        Transform spawnPoint = spawnPoints[randomIndex];
        Instantiate(lifePrefab, spawnPoint.position, Quaternion.identity);
    }
}
