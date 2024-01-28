using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    public float speed = 5f;  // Speed of the fireball
    public float lifetime = 3f;  // Time before the fireball is destroyed

    void Start()
    {
        // Set the initial velocity of the fireball (assuming it moves along the X-axis)
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * speed;

        // Schedule the destruction of the fireball after its lifetime
        Destroy(gameObject, lifetime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the fireball collides with the player (or another relevant object)
        if (other.CompareTag("Player"))
        {
            // Handle what happens when the fireball hits the player
            // For example, you might deal damage to the player or trigger an animation
            // You can customize this part based on your game's logic
            Debug.Log("Fireball hit the player!");
            Destroy(gameObject);  // Destroy the fireball upon collision with the player
        }
    }
}
