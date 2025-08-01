using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    [Header("---------Audio Source--------")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;

    [Header("---------Audio Clip--------")]
    public AudioClip background;
    public AudioClip level1;
    public AudioClip Click;
    public AudioClip Shot;

    public static AudioManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    
    private void Start()
    {
        musicSource.clip = background;
        musicSource.Play();
    }

    public void PlaySFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }

    public void PlayMusic(AudioClip clip)
    {
        if (musicSource.clip == clip) return; // já está tocando, não precisa mudar
        musicSource.Stop();
        musicSource.clip = clip;
        musicSource.Play();

        // Garante que o volume seja reaplicado após trocar a música
        FindFirstObjectByType<VolumeSettings>()?.SetMusicVolume();
    }
}
