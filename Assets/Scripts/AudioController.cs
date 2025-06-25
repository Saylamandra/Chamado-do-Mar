using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AudioController : MonoBehaviour
{
    public AudioSource musicSource;  // Fonte da música
    public AudioSource sfxSource;    // Fonte de efeitos (tiro do submarino)
    
    public AudioClip lobbyMusic;     // Música do lobby
    public AudioClip level1Music;    // Música do nível 1
    public AudioClip submarineShot;  // Som do tiro

    public AudioMixer mixer;         // Mixer com MusicVol e SFXVol

    public Slider musicSlider;       // Slider da música
    public Slider sfxSlider;         // Slider dos efeitos

    private static AudioController instance;

    void Awake()
    {
        // Garante que só exista um AudioController e não seja destruído
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            SceneManager.sceneLoaded += OnSceneLoaded;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        // Começa a música do lobby assim que o jogo começa
        PlayMusic(lobbyMusic);
    }

    void Update()
    {
    if (musicSlider == null)
        {
            GameObject ms = GameObject.Find("MusicSlider");
            if (ms != null)
                musicSlider = ms.GetComponent<Slider>();
        }

    if (sfxSlider == null)
        {
            GameObject ss = GameObject.Find("SFXSlider");
            if (ss != null)
                sfxSlider = ss.GetComponent<Slider>();
        }
    }


    public void PlayMusic(AudioClip clip)
    {
        if (musicSource.clip == clip) return;  // Não reinicia se já estiver tocando
        musicSource.clip = clip;
        musicSource.Play();
    }

    public void PlaySFX(AudioClip clip)
    {
        sfxSource.PlayOneShot(clip);
    }

    public void ChangeMusicVolume()
    {
        mixer.SetFloat("MusicVol", musicSlider.value);
    }

    public void ChangeSFXVolume()
    {
        mixer.SetFloat("SFXVol", sfxSlider.value);
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Troca de música automática conforme a cena
        if (scene.name == "SampleScene")
        {
            PlayMusic(level1Music);
        }
        else if (scene.name == "ImagemInicial" || scene.name == "StartMenu")
        {
            PlayMusic(lobbyMusic);
        }
        else if (scene.name == "OptionsMenu" || scene.name == "VolumeMenu")
        {
            PlayMusic(lobbyMusic);
        }
    }
}
