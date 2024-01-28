using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour
{
    public GameObject fireballPrefab;  // Reference to the fireball prefab
    public Transform fireballSpawnPoint;  // Point where the fireball will be spawned
    public float spitInterval = 3f;  // Time interval between spitting fireballs
    public float bossHealth = 100f;  // Example health value

    private float timer = 0f;
    private Animator animator;

    void Start()
    {
        // Get the Animator component
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // Update the timer
        timer += Time.deltaTime;

        // Check if it's time to spit a fireball
        if (timer >= spitInterval)
        {
            SpitFireball();  // Call the function to spit a fireball
            timer = 0f;  // Reset the timer

            // When attacking
            animator.SetBool("IsAttacking", true);
        }

        // Check for conditions to transition to the Death state
        if (bossHealth <= 0)
        {
            // Set the "IsDead" parameter to trigger the Death state transition
            animator.SetBool("IsDead", true);
        }
        else
        {
            // When done attacking or after a delay
            animator.SetBool("IsAttacking", false);
        }
    }

    void SpitFireball()
    {
        // Instantiate a fireball at the specified spawn point
        Instantiate(fireballPrefab, fireballSpawnPoint.position, fireballSpawnPoint.rotation);
    }

    // Other methods for handling boss damage or other interactions
    public void TakeDamage(float damageAmount)
    {
        // Reduce boss health
        bossHealth -= damageAmount;

        // Check if health is zero or below
        if (bossHealth <= 0)
        {
            // Set the "IsDead" parameter to trigger the Death state transition
            animator.SetBool("IsDead", true);
        }
    }
}
