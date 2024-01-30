using System.Collections;
using UnityEngine;

public class BossController : MonoBehaviour
{
    public float detectionRadius = 5f; // Adjust this value based on your desired detection range
    public Transform player; // Assign the player's transform in the Inspector
    public GameObject fireballPrefab; // Assign the fireball prefab in the Inspector
    public Animator bossAnimator;
    public GameObject firePoint;

    private bool canShoot = true;

    void Start()
    {
        StartCoroutine(ShootFireballRoutine());
    }

    void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        // Check if the player is in the same room and within the detection radius
        if (IsPlayerInSameRoom(distanceToPlayer) && canShoot)
        {
            // Your additional logic for when the player is in the same room and within the detection radius
            bossAnimator.SetTrigger("Attack");
        }
    }

    IEnumerator ShootFireballRoutine()
    {
        while (true)
        {
            // Check if the player is in the same room and within the detection radius before shooting
            float distanceToPlayer = Vector3.Distance(transform.position, player.position);
            if (IsPlayerInSameRoom(distanceToPlayer) && canShoot)
            {
                //ShootFireball();
                canShoot = false; // Prevent shooting for a few seconds

                // Wait for 5 seconds before shooting again
                yield return new WaitForSeconds(5f);

                canShoot = true; // Allow shooting again
            }

            yield return null;
        }
    }

    void ShootFireball()
    {
        // Instantiate a fireball prefab and set its position and direction
        GameObject fireball = Instantiate(fireballPrefab, firePoint.transform.position, Quaternion.identity);
        Vector3 direction = (player.position - firePoint.transform.position).normalized;
        fireball.GetComponent<FireballController>().SetDirection(direction);
    }

    bool IsPlayerInSameRoom(float distanceToPlayer)
    {
        // Check if the player is in the same room and within the detection radius
        if (distanceToPlayer <= detectionRadius)
        {
            // Implement your own logic to check if the player is in the same room
            // This could involve checking the player's position, room boundaries, etc.
            // Return true if the player is in the same room; otherwise, return false.
            // Replace this function with your actual implementation.
            return true; // Placeholder, replace with your logic
        }

        return false;
    }
}
