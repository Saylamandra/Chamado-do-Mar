using UnityEngine;

public class PauseController : MonoBehaviour
{
    // serve pra saber se o jogo já está pausado ou não
    private bool isPaused = false;

    public GameObject pauseMenu;  

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }
    }

    public void TogglePause()
    {
        isPaused = !isPaused;

        Time.timeScale = isPaused ? 0f : 1f;

        if (pauseMenu != null)
        {
            pauseMenu.SetActive(isPaused);
        }

        Debug.Log(isPaused ? "Jogo pausado" : "Jogo retomado");
    }

    // Método para despausar pelo botão "Continuar"
    public void ResumeGame()
    {
        isPaused = false;
        Time.timeScale = 1f;

        if (pauseMenu != null)
        {
            pauseMenu.SetActive(false);
        }

        Debug.Log("Jogo retomado pelo botão");
    }
}
