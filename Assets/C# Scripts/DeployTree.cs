using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeployTree : MonoBehaviour
{
    public GameObject treePrefab;
    public float respawnTime = 1.0f;
    private float screenHalfWidth;
    private float spawnYPosition;

    void Start()
    {
        // Calculate half of the screen width in world units
        screenHalfWidth = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0, 0)).x;
        
        // Calculate the Y position for spawning trees (e.g., the bottom of the screen)
        spawnYPosition = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0)).y;

        // Start the TreeWave coroutine
        StartCoroutine(TreeWave());
    }

    private void SpawnEnemy()
{
    // Calculate a random X position within the screen bounds
    float spawnXPosition = Random.Range(-screenHalfWidth, screenHalfWidth);

    // Instantiate the tree at the calculated position
    GameObject newTree = Instantiate(treePrefab, new Vector2(spawnXPosition, spawnYPosition), Quaternion.identity);

    // Destroy the cloned object after a specified time (e.g., 5 seconds)
    Destroy(newTree, 5f);
}


    private IEnumerator TreeWave()
    {
        while (true)
        {
            // Wait for the specified respawn time
            yield return new WaitForSeconds(respawnTime);

            // Spawn a tree
            SpawnEnemy();
        }
    }
}
