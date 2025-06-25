using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CheckboxPlayButton : MonoBehaviour
{
    public Sprite checkboxEmpty;
    public Sprite checkboxMarked;
    public string sceneToLoad;

    //armazena a referência ao componente Image do GameObject onde esse script está
    private Image checkboxImage;

    //indica se o checkbox está marcado. Começa como false.
    private bool isChecked = false;

    void Start()
    {
        //pega o componente Image que está no mesmo GameObject
        checkboxImage = GetComponent<Image>();

        //inicializa o checkbox como desmarcado.
        SetCheckbox(false);
    }

    public void OnClickPlay()
    {
        //Se o botão já estiver marcado ou se sceneToLoad estiver vazia ou nula, não faz nada
        if (isChecked || string.IsNullOrEmpty(sceneToLoad)) return;

        //Marca o checkbox visualmente e internamente
        SetCheckbox(true);
        //Chama o método LoadScene() depois de 0.3 segundos
        Invoke(nameof(LoadScene), 0.3f);
    }

    void LoadScene()
    {
        //garante que o tempo volte ao normal
        Time.timeScale = 1f;
        //Usa o SceneManager para carregar a cena com o nome indicado em sceneToLoad
        SceneManager.LoadScene(sceneToLoad);
    }

    //Marca ou desmarca o checkbox/Atualiza o isChecked
    void SetCheckbox(bool marked)
    {
        isChecked = marked;

        //Se o componente Image existe, troca o sprite entre checkboxMarked e checkboxEmpty, dependendo do valor de marked
        if (checkboxImage != null)
            checkboxImage.sprite = marked ? checkboxMarked : checkboxEmpty;
    }
}
