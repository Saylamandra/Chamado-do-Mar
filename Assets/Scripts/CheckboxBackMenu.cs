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
        // Troca a música para a música do menu
        AudioManager.instance.PlayMusic(AudioManager.instance.background);

        yield return new WaitForSecondsRealtime(0.3f);

        Time.timeScale = 1f;

        PauseController pauseController = Object.FindFirstObjectByType<PauseController>();
        if (pauseController != null)
            Destroy(pauseController.gameObject);

        SceneManager.LoadScene(sceneToLoad);
    }

    void SetCheckbox(bool marked)
    {
        isChecked = marked;

        if (checkboxImage != null)
            checkboxImage.sprite = marked ? checkboxMarked : checkboxEmpty;
    }
}
