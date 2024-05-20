using UnityEngine;

public class BackgroundController : MonoBehaviour
{
    public float scrollSpeed = 0.1f;
    public float tileSizeY;

    private Vector3 startPosition;

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        float newPosition = Mathf.Repeat(Time.time * scrollSpeed, tileSizeY);
        transform.position = startPosition + Vector3.up * newPosition;
    }
}