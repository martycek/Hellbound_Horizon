using System.Collections;
using UnityEngine;

public class FireballController : MonoBehaviour
{
    private Animator fireballAnimator;
    public float speed = 3f; // Adjust the speed based on your preference
    private Vector3 targetPosition;

    void Start()
    {
        fireballAnimator = GetComponent<Animator>();
    }

    public void SetDirection(Vector3 direction)
    {
        // Set the rotation based on the fireball's movement direction
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        //fireballAnimator.SetTrigger("Shoot");

        // Set the target position based on the player's position
        targetPosition = direction.normalized * 1000f; // Adjust the distance as needed
    }

    void Update()
    {
        // Move towards the player
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
        
        // Check if the fireball reaches the target position
        if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
        {
            // Destroy the fireball when it reaches the target
            Destroy(gameObject);
        }
    }
}
