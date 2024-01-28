using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballController : MonoBehaviour
{
    private Animator fireballAnimator;

    void Start()
    {
        fireballAnimator = GetComponent<Animator>();
    }

    public void SetDirection(Vector3 direction)
    {
        // Set the animation direction based on the fireball's movement direction
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        // Trigger the animation
        fireballAnimator.SetTrigger("Shoot");
    }
}
