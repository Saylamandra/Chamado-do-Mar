using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Header("Prefab dos inimigos e pontos de spawn")]
    public GameObject[] enemyPrefabs; // [0] inimigo 1, [1] inimigo 2, [2] inimigo 3
    public Transform[] spawnPoints;

    [Header("Intervalo entre spawns")]
    public float spawnInterval = 2f;

    [Header("Controle de inimigo difícil")]
    public int maxToughEnemies = 3; // Quantos inimigos difíceis podem existir ao mesmo tempo
    private int currentToughEnemies = 0;

    private int currentWave = 1;
    private bool canSpawn = true;

    void Start()
    {
        InvokeRepeating(nameof(SpawnEnemy), 0f, spawnInterval);
    }

    public void SetWave(int wave)
    {
        currentWave = wave;

        if (wave == 1)
            spawnInterval = 2f;
        else if (wave == 2)
            spawnInterval = 2f;
        else if (wave == 3)
            spawnInterval = 2f;
        else if (wave == 4)
            spawnInterval = 1.5f;
        else if (wave >= 5)
            spawnInterval = 1f;

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
        GameObject prefabToSpawn = null;

        switch (currentWave)
        {
            case 1:
                prefabToSpawn = enemyPrefabs[0];
                break;

            case 2:
                if (enemyPrefabs.Length >= 2)
                    prefabToSpawn = enemyPrefabs[1];
                break;

            case 3:
                if (enemyPrefabs.Length >= 3 && currentToughEnemies < maxToughEnemies)
                    prefabToSpawn = enemyPrefabs[2];
                break;

            case 4:
                if (enemyPrefabs.Length >= 2)
                {
                    int randomIndex = Random.Range(0, 2);
                    prefabToSpawn = enemyPrefabs[randomIndex];
                }
                break;

            default:
                int randomAll = Random.Range(0, enemyPrefabs.Length);
                // Se sorteou o inimigo difícil, verifica o limite
                if (randomAll == 2 && currentToughEnemies >= maxToughEnemies)
                {
                    // Força o spawn de um inimigo mais fraco se o limite foi atingido
                    randomAll = Random.Range(0, 2);
                }
                prefabToSpawn = enemyPrefabs[randomAll];
                break;
        }

        if (prefabToSpawn != null)
        {
            GameObject newEnemy = Instantiate(prefabToSpawn, point.position, Quaternion.identity);

            // Se for inimigo difícil (index 2), aumenta a contagem
            if (prefabToSpawn == enemyPrefabs[2])
            {
                currentToughEnemies++;

                // Passa uma referência do spawner para o inimigo
                ToughEnemy tough = newEnemy.AddComponent<ToughEnemy>();
                tough.spawner = this;
            }
        }
    }

    // Função para o inimigo difícil avisar que morreu
    public void OnToughEnemyDeath()
    {
        currentToughEnemies--;
    }
}
