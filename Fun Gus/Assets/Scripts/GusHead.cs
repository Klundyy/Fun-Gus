using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GusHead : MonoBehaviour
{
    public Rigidbody2D playerRigidbody; // Reference to the player's Rigidbody2D
    public float bounceForce = 10f; // Force applied to bounce

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the head collides with the ground
        if (collision.gameObject.CompareTag("Ground"))
        {
            // Apply an upward force to the player's Rigidbody2D
            playerRigidbody.AddForce(Vector2.up * bounceForce, ForceMode2D.Impulse);
        }
    }
}
