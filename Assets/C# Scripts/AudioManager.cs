using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    [SerializeField] private AudioSource musicSource;
    [SerializeField] private AudioSource SFXSource;

    public AudioClip background;
    public AudioClip death;
    public AudioClip click;

    private bool isMusicPlaying = true;

    private void Awake()
    {
        // Ensure only one instance of AudioManager exists
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Preserve AudioManager across scene changes
        }
        else
        {
            Destroy(gameObject); // Destroy duplicate instances
            return;
        }

        PlayBackgroundMusic();
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.buildIndex == 0 && isMusicPlaying && !musicSource.isPlaying)
        {
            musicSource.Play();
        }
    }

    public void PlayBackgroundMusic()
    {
        if (musicSource != null && background != null)
        {
            musicSource.clip = background;
            musicSource.Play();
        }
    }

    public void ToggleMusic()
    {
        if (musicSource != null)
        {
            if (isMusicPlaying)
            {
                musicSource.Pause();
            }
            else
            {
                musicSource.Play();
            }
            isMusicPlaying = !isMusicPlaying;
        }
    }
}
