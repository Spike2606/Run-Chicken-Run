using UnityEngine;

public class MoveController : MonoBehaviour
{
    public float speed = 1f;
    public float speedIncreaseRate = 0.1f; // Rate at which speed increases over time
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
            // Randomize the X position within the specified range.
            transform.position = new Vector3(Random.Range(xMin, xMax), transform.position.y, transform.position.z);
        }
    }

    private void Update()
    {
        // Increase speed over time
        speed += speedIncreaseRate * Time.deltaTime;
        
        // Move the object upwards along the Y-axis.
        transform.position += new Vector3(0, speed * Time.deltaTime, 0);

        // Check if the object has reached the despawn position.
        if (transform.position.y > despawnPositionY)
        {
            if (destroyWhenReachedDespawnPoint)
            {
                Destroy(gameObject);
            }
            else
            {
                // Reset the position to the spawn point.
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
