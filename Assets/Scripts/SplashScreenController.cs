using UnityEngine;
using UnityEngine.SceneManagement;

public class SplashScreenController : MonoBehaviour
{
    public float delayBeforeLoading = 3f; 
    public string sceneToLoad = "StartMenu"; 
    

    void Start()
    {
        Invoke("LoadNextScene", delayBeforeLoading);
    }

    void LoadNextScene()
    {
        SceneManager.LoadScene(sceneToLoad);
    }
}
