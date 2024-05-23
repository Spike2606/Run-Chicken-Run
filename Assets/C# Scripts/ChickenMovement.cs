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
    public bool isDead = false; // Zmienna przechowuj¹ca stan œmierci

    void Awake()
    {
        Time.timeScale = 1f;
        body = GetComponent<Rigidbody2D>();
        gameOverPanel.SetActive(false);
        isDead = false; // Inicjalizacja zmiennej
    }

    private void Update()
    {
        if (isDead) return; // Jeœli obiekt jest martwy, nie wykonuj aktualizacji ruchu

        float horizontalInput = Input.GetAxis("Horizontal");
        body.velocity = new Vector2(horizontalInput * speed, body.velocity.y);

        if (horizontalInput > 0.01f)
            transform.localScale = Vector3.one;
        else if (horizontalInput < -0.01f)
            transform.localScale = new Vector3(-1, 1, 1);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        isDead = true; // Ustaw zmienn¹ na true, gdy obiekt umiera
        gameOverPanel.SetActive(true);
        Time.timeScale = 0f;

        if (collisionSound != null)
            collisionSound.Play();
    }

    public void RestartGame()
    {
        Time.timeScale = 1f; // Wznów czas
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // Prze³aduj bie¿¹c¹ scenê
    }

    public void BackToMainMenu()
    {
        SceneManager.LoadScene(0); // Za³aduj scenê o indeksie 0 (menu g³ówne)
    }
}
