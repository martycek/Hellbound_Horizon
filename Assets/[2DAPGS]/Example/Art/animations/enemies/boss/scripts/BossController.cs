using System.Collections;
using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class BossController : MonoBehaviour
{
    public Transform player; // Assign the player's transform in the Inspector
    public GameObject fireballPrefab; // Assign the fireball prefab in the Inspector

    private bool canShoot = true;

    void Start()
    {
        StartCoroutine(ShootFireballRoutine());
    }

    void Update()
    {
        // Check if the player is in the same room (you'll need to implement your own logic here)
        if (IsPlayerInSameRoom())
        {
            // Your additional logic for when the player is in the same room
        }
    }

    IEnumerator ShootFireballRoutine()
    {
        while (true)
        {
            // Check if the player is in the same room before shooting
            if (IsPlayerInSameRoom() && canShoot)
            {
                ShootFireball();
                canShoot = false; // Prevent shooting for a few seconds

                // Wait for 3 seconds before shooting again
                yield return new WaitForSeconds(3f);
                
                canShoot = true; // Allow shooting again
            }

            yield return null;
        }
    }

    void ShootFireball()
    {
        // Instantiate a fireball prefab and set its position and direction
        GameObject fireball = Instantiate(fireballPrefab, transform.position, Quaternion.identity);
        Vector3 direction = (player.position - transform.position).normalized;
        fireball.GetComponent<FireballController>().SetDirection(direction);
    }

    bool IsPlayerInSameRoom()
    {
        // Implement your own logic to check if the player is in the same room
        // This could involve checking the player's position, room boundaries, etc.
        // Return true if the player is in the same room; otherwise, return false.
        // Replace this function with your actual implementation.
        return true; // Placeholder, replace with your logic
    }
}
