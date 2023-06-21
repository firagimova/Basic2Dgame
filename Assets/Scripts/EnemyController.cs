using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float moveSpeed = 1f; // Speed at which the enemy moves
    public float movementDistance = 1f; // Distance the enemy moves to either side
    private bool facingRight = false; // Whether the enemy is facing right or not
    private Vector2 startPos; // Starting position of the enemy

    private void Start()
    {
        startPos = transform.position;
    }

    private void FixedUpdate()
    {
        if (facingRight) // If the enemy is facing right, move right
        {
            transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);
        }
        else // Otherwise, move left
        {
            transform.Translate(-Vector2.right * moveSpeed * Time.deltaTime);
        }

        // If the enemy has moved its movement distance to either side, flip it
        if (Mathf.Abs(transform.position.x - startPos.x) >= movementDistance)
        {
            Flip();
        }
    }

    private void Flip()
    {
        facingRight = !facingRight; // Invert the facingRight flag
        Vector3 scale = transform.localScale;
        scale.x *= -1; // Flip the enemy by inverting the x-scale
        transform.localScale = scale;
    }
}
