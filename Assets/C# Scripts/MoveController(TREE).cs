using UnityEngine;

public class MoveController : MonoBehaviour
{
    public float speed = 1f;
    public float maxSpeed = 10f; // Maksymalna pr�dko��
    public float speedIncreaseRate = 0.1f; // Tempo zwi�kszania pr�dko�ci w czasie
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
            // Randomizuj pozycj� X w okre�lonym zakresie.
            transform.position = new Vector3(Random.Range(xMin, xMax), transform.position.y, transform.position.z);
        }
    }

    private void Update()
    {
        // Sprawd�, czy pr�dko�� nie przekracza maksymalnej warto�ci
        if (speed < maxSpeed)
        {
            // Zwi�kszaj pr�dko�� w czasie, dop�ki nie przekroczy maksymalnej warto�ci
            speed += speedIncreaseRate * Time.deltaTime;
        }
        
        // Poruszaj obiekt w g�r� wzd�u� osi Y.
        transform.position += new Vector3(0, speed * Time.deltaTime, 0);

        // Sprawd�, czy obiekt osi�gn�� pozycj� wyj�ciow�.
        if (transform.position.y > despawnPositionY)
        {
            if (destroyWhenReachedDespawnPoint)
            {
                Destroy(gameObject);
            }
            else
            {
                // Zresetuj pozycj� do punktu spawnowania.
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
