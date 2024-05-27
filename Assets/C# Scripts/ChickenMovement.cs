using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class ChickenMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    private Rigidbody2D body;
    public GameObject gameOverPanel;
    public AudioSource collisionSound;
    public bool isDead = false; 

    private bool isGameStarted = false;

    public TextMeshProUGUI startGameText;

    void Awake()
    {
        Time.timeScale = 0f;
        body = GetComponent<Rigidbody2D>();
        gameOverPanel.SetActive(false);
        isDead = false; 
        startGameText = GameObject.Find("startGameText").GetComponent<TextMeshProUGUI>();
        startGameText.gameObject.SetActive(true);
    }

    private void Update()
    {
        if (isDead) return; 

        if (!isGameStarted)
        {
            // Check for 'a', 'd', or arrow key presses to start the game
            if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D) || 
                Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow))
            {
                isGameStarted = true;
                Time.timeScale = 1f;
                startGameText.gameObject.SetActive(false); // Unfreeze the game
            }
            return; // Do not process movement until the game has started
        }

        float horizontalInput = Input.GetAxis("Horizontal");
        body.velocity = new Vector2(horizontalInput * speed, body.velocity.y);

        if (horizontalInput > 0.01f)
            transform.localScale = Vector3.one;
        else if (horizontalInput < -0.01f)
            transform.localScale = new Vector3(-1, 1, 1);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        isDead = true; 
        gameOverPanel.SetActive(true);
        Time.timeScale = 0f;

        if (collisionSound != null)
            collisionSound.Play();
    }

    public void RestartGame()
    {
        Time.timeScale = 1f; 
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); 
        
    }

    public void BackToMainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
