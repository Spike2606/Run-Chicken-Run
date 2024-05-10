using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoxMovement : MonoBehaviour
{
    public Transform target; // Reference to the chicken's transform

    [SerializeField] private float speed;

    private Rigidbody2D body;
    private bool isChickenMoving = false; // Flag to track chicken's movement

    void Awake()
    {
        body = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (target != null)
        {
            // Check if the chicken is moving
            float horizontalInput = target.GetComponent<Rigidbody2D>().velocity.x;
            isChickenMoving = Mathf.Abs(horizontalInput) > 0.01f;

            if (isChickenMoving)
            {
                Vector2 targetPosition = new Vector2(target.position.x, transform.position.y);
                Vector2 direction = (targetPosition - (Vector2)transform.position).normalized;
                body.velocity = direction * speed;

                // Flip the sprite based on movement direction
                if (direction.x > 0)
                    transform.localScale = Vector3.one;
                else if (direction.x < 0)
                    transform.localScale = new Vector3(-1, 1, 1);
            }
            else
            {
                // If chicken is not moving, stop the Fox
                body.velocity = Vector2.zero;
            }
        }
        else
        {
            // If target is null, stop moving
            body.velocity = Vector2.zero;
        }
    }
}
