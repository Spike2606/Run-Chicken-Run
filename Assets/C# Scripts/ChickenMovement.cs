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
    public bool isDead = false; // Zmienna przechowuj�ca stan �mierci

    void Awake()
    {
        Time.timeScale = 1f;
        body = GetComponent<Rigidbody2D>();
        gameOverPanel.SetActive(false);
        isDead = false; // Inicjalizacja zmiennej
    }

    private void Update()
    {
        if (isDead) return; // Je�li obiekt jest martwy, nie wykonuj aktualizacji ruchu

        float horizontalInput = Input.GetAxis("Horizontal");
        body.velocity = new Vector2(horizontalInput * speed, body.velocity.y);

        if (horizontalInput > 0.01f)
            transform.localScale = Vector3.one;
        else if (horizontalInput < -0.01f)
            transform.localScale = new Vector3(-1, 1, 1);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        isDead = true; // Ustaw zmienn� na true, gdy obiekt umiera
        gameOverPanel.SetActive(true);
        Time.timeScale = 0f;

        if (collisionSound != null)
            collisionSound.Play();
    }

    public void RestartGame()
    {
        Time.timeScale = 1f; // Wzn�w czas
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // Prze�aduj bie��c� scen�
    }

    public void BackToMainMenu()
    {
        SceneManager.LoadScene(0); // Za�aduj scen� o indeksie 0 (menu g��wne)
    }
}
