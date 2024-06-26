using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeMovement : MonoBehaviour
{
    public float speed = 8.0f;
    private Rigidbody2D rb;
    private Vector2 screenBounds;

   
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(0, speed);
        screenBounds=Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
       
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < -screenBounds.y)
        {
            Destroy(this.gameObject);
        }
       
    }
}
