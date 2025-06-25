using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Header("Prefab do inimigo e pontos de spawn")]
    public GameObject[] enemyPrefabs; // Vários inimigos para escolher por wave
    public Transform[] spawnPoints;

    [Header("Intervalo entre spawns")]
    public float spawnInterval = 2f;

    private int currentWave = 1;
    private bool canSpawn = true;

    void Start()
    {
        InvokeRepeating(nameof(SpawnEnemy), 0f, spawnInterval);
    }

    public void SetWave(int wave)
    {
        currentWave = wave;

        // Define um novo intervalo dependendo da wave
        if (wave == 1)
            spawnInterval = 2f;
        else if (wave == 2)
            spawnInterval = 3f;
        else
            spawnInterval = 2f;

        // Reinicia o InvokeRepeating com o novo intervalo
        CancelInvoke();
        InvokeRepeating(nameof(SpawnEnemy), 0f, spawnInterval);
    }

    public void SetSpawning(bool state)
    {
        canSpawn = state;
    }

   void SpawnEnemy()
{
    if (!canSpawn || enemyPrefabs.Length == 0) return;

    Transform point = spawnPoints[Random.Range(0, spawnPoints.Length)];

    GameObject prefabToSpawn;
    int prefabCount = enemyPrefabs.Length;

    if (currentWave == 1)
    {
        prefabToSpawn = enemyPrefabs[0];
    }
    else if (currentWave == 2 && prefabCount >= 2)
    {
        prefabToSpawn = enemyPrefabs[1];
    }
    else if ((currentWave == 3 || currentWave == 4) && prefabCount >= 2)
    {
        int rangeMax = Mathf.Min(2, prefabCount); // garante que não vai ultrapassar
        prefabToSpawn = enemyPrefabs[Random.Range(0, rangeMax)];
    }
    else if (currentWave >= 5)
    {
        prefabToSpawn = enemyPrefabs[Random.Range(0, prefabCount)];
    }
    else
    {
        prefabToSpawn = enemyPrefabs[prefabCount - 1];
    }

    Instantiate(prefabToSpawn, point.position, Quaternion.identity);
}

}
