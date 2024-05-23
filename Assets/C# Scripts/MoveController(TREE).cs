using UnityEngine;

public class MoveController : MonoBehaviour
{
    public float speed = 1f;
    public float maxSpeed = 10f; // Maksymalna prêdkoœæ
    public float speedIncreaseRate = 0.1f; // Tempo zwiêkszania prêdkoœci w czasie
    public float spawnPositionY;
    public float despawnPositionY;
    public bool randomizeTheXPosition;
    public float xMin;
    public float xMax;
    public bool destroyWhenReachedDespawnPoint;
    public bool alwaysMove;
    
    private void Start()
    {
        if (randomizeTheXPosition)
        {
            // Randomizuj pozycjê X w okreœlonym zakresie.
            transform.position = new Vector3(Random.Range(xMin, xMax), transform.position.y, transform.position.z);
        }
    }

    private void Update()
    {
        // SprawdŸ, czy prêdkoœæ nie przekracza maksymalnej wartoœci
        if (speed < maxSpeed)
        {
            // Zwiêkszaj prêdkoœæ w czasie, dopóki nie przekroczy maksymalnej wartoœci
            speed += speedIncreaseRate * Time.deltaTime;
        }
        
        // Poruszaj obiekt w górê wzd³u¿ osi Y.
        transform.position += new Vector3(0, speed * Time.deltaTime, 0);

        // SprawdŸ, czy obiekt osi¹gn¹³ pozycjê wyjœciow¹.
        if (transform.position.y > despawnPositionY)
        {
            if (destroyWhenReachedDespawnPoint)
            {
                Destroy(gameObject);
            }
            else
            {
                // Zresetuj pozycjê do punktu spawnowania.
                if (randomizeTheXPosition)
                {
                    transform.position = new Vector3(Random.Range(xMin, xMax), spawnPositionY, transform.position.z);
                }
                else
                {
                    transform.position = new Vector3(transform.position.x, spawnPositionY, transform.position.z);
                }
            }
        }
    }
}
