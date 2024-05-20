using UnityEngine;

public class BackgroundController : MonoBehaviour
{
    public float scrollSpeed = 0.1f;
    public float spawnPositionY;
    public float despawnPositionY;

    private Vector3 startPosition;
    private float backgroundHeight;

    void Start()
    {
        startPosition = transform.position;
        
        // Calculate the height of the background using the Renderer bounds.
        Renderer renderer = GetComponent<Renderer>();
        if (renderer != null)
        {
            backgroundHeight = renderer.bounds.size.y;
        }
        else
        {
            Debug.LogError("Renderer component not found on the background object.");
        }
    }

    void Update()
    {
        // Calculate the current position based on time and scroll speed.
        float newPosition = Mathf.Repeat(Time.time * scrollSpeed, backgroundHeight);
        transform.position = startPosition + Vector3.up * newPosition;
    }
}
