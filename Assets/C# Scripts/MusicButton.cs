using UnityEngine;
using UnityEngine.UI;

public class MusicButton : MonoBehaviour
{
    private Button button;

    private void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(ToggleMusic);
    }

    private void ToggleMusic()
    {
        if (AudioManager.instance != null)
        {
            AudioManager.instance.ToggleMusic();
        }
    }
}