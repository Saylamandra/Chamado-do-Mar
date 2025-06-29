using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CheckboxPlayButton : MonoBehaviour
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
        Invoke(nameof(LoadScene), 0.3f);
    }

    void LoadScene()
    {
        // Troca a música para a música do nível
        AudioManager.instance.PlayMusic(AudioManager.instance.level1);

        Time.timeScale = 1f;

        SceneManager.LoadScene(sceneToLoad);
    }

    void SetCheckbox(bool marked)
    {
        isChecked = marked;

        if (checkboxImage != null)
            checkboxImage.sprite = marked ? checkboxMarked : checkboxEmpty;
    }
}
