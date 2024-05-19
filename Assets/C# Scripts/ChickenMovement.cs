using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChickenMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    private Rigidbody2D body;
    public GameObject gameOverPanel;
    public AudioSource collisionSound;

    void Awake()
    {
        Time.timeScale = 1f;
        body = GetComponent<Rigidbody2D>();
        gameOverPanel.SetActive(false);
    }

    private void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        body.velocity = new Vector2(horizontalInput * speed, body.velocity.y);


        if (horizontalInput > 0.01f)
        transform.localScale = Vector3.one;
        else if (horizontalInput < -0.01f)
            transform.localScale = new Vector3(-1, 1, 1);

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
          gameOverPanel.SetActive(true);
        Time.timeScale = 0f; 

        if (collisionSound != null)
            collisionSound.Play();
    }

     public void RestartGame()
    {
        Time.timeScale = 1f; // Resume time
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // Reload the current scene
    }

    public void BackToMainMenu()
    {
        SceneManager.LoadScene(0); // Load the scene with index 0 (main menu)
    }
}