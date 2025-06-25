using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class CheckboxBackMenu : MonoBehaviour
{
    public Sprite checkboxEmpty;
    public Sprite checkboxMarked;
    public string sceneToLoad;

    private Image checkboxImage;
    private bool isChecked = false;

    void Start()
    {
        checkboxImage = GetComponent<Image>();
        SetCheckbox(false);
    }

    public void OnClickPlay()
    {
        if (isChecked || string.IsNullOrEmpty(sceneToLoad)) return;

        SetCheckbox(true);
        Debug.Log("CARREGANDO CENA: " + sceneToLoad);

        StartCoroutine(LoadSceneAfterDelay());
    }

    IEnumerator LoadSceneAfterDelay()
    {
        // Espera 0.3 segundos reais (independente do timeScale)
        yield return new WaitForSecondsRealtime(0.3f);

        // Garante que o tempo volte ao normal
        Time.timeScale = 1f;

        // (Opcional) destrói o controlador de pausa, se ainda existir
        PauseController pauseController = Object.FindFirstObjectByType<PauseController>();
        if (pauseController != null)
            Destroy(pauseController.gameObject);

        // Carrega a cena desejada
        SceneManager.LoadScene(sceneToLoad);
    }

    void SetCheckbox(bool marked)
    {
        isChecked = marked;

        if (checkboxImage != null)
            checkboxImage.sprite = marked ? checkboxMarked : checkboxEmpty;
    }
}
