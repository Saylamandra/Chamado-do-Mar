using UnityEngine;
using TMPro;
using System.Collections;

public class WaveManager : MonoBehaviour
{
    private bool levelCleared = false;
    public TextMeshProUGUI waveCounterText;
    public TextMeshProUGUI waveMessageText;
    public GameObject levelClearPanel; 
    public EnemySpawner[] spawners; // arraste todos os spawners aqui pelo inspetor



    public int maxWaves = 5;
    private int currentWave = 1;

    private void Start()
    {
        UpdateWaveText();
    }

    private void Update()
{
    if (ScoreManager.Instance != null)
    {
        if (currentWave < maxWaves && ScoreManager.Instance.GetScore() >= currentWave * 200)
        {
            StartCoroutine(AdvanceWave());
        }
        else if (currentWave == maxWaves && ScoreManager.Instance.GetScore() >= currentWave * 200 && !levelCleared)
        {
            levelCleared = true;
            levelClearPanel.SetActive(true);
        }
    }
}

    IEnumerator AdvanceWave()
{
    currentWave++;

    waveMessageText.text = "Wave Clear!";

    // Para os spawners
    foreach (var spawner in spawners)
    {
        spawner.SetSpawning(false);
    }

    // Destroi todos os inimigos com a tag "inimigo"
    GameObject[] inimigos = GameObject.FindGameObjectsWithTag("enemy");
    foreach (GameObject inimigo in inimigos)
    {
        Destroy(inimigo);
    }

    yield return new WaitForSeconds(2f);

    // Libera os spawners novamente
    foreach (var spawner in spawners)
    {
        spawner.SetWave(currentWave);
        spawner.SetSpawning(true);
    }

    waveMessageText.text = "";
    UpdateWaveText();
}



    void UpdateWaveText()
    {
        waveCounterText.text = $"Wave {currentWave}/{maxWaves}";
    }
}

