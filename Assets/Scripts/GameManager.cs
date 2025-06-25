using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public GameObject gameOverPanel;
    public void RestartLevel()
    {
        Time.timeScale = 1f; // Volta o tempo ao normal
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // Recarrega a cena atual
    }


    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    public void TriggerGameOver()
    {
        Time.timeScale = 0f; // pausa o jogo
        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(true);
        }
    }
}
