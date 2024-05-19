using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FoxMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    private Rigidbody2D body;
    

    void Awake()
    {
        
        body = GetComponent<Rigidbody2D>();
       
    }

    private void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        body.velocity = new Vector2(horizontalInput * speed, body.velocity.y);


        if (horizontalInput > 0.01f)
        transform.localScale = Vector3.one;
        else if (horizontalInput < -0.01f)
            transform.localScale = new Vector3(-1, 1, 1);

    }
}