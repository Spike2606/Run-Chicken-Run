using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuPanel;
    private ChickenMovement chickenMovement; 

    void Start()
    {
        if (chickenMovement == null)
        {
            chickenMovement = FindObjectOfType<ChickenMovement>();
        }
    }
    public void PauseGame()
    {
        if (chickenMovement != null && !chickenMovement.isDead)
        {
            Time.timeScale = 0;
            pauseMenuPanel.SetActive(true);
        }
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        pauseMenuPanel.SetActive(false);
    }

    public void BackToMainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
}
