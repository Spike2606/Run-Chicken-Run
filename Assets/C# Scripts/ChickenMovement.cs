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
    public bool isDead = false; 

    void Awake()
    {
        Time.timeScale = 1f;
        body = GetComponent<Rigidbody2D>();
        gameOverPanel.SetActive(false);
        isDead = false; 
    }

    private void Update()
    {
        if (isDead) return; 

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
