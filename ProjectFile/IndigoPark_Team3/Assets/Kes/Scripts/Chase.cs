using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chase : MonoBehaviour
{
    public Transform target; // the enemy's target
    public float moveSpeed = 3f; // move speed
    public float rotationSpeed = 3f; // speed of turning
    public float range = 10f; // Range within which the target will be detected
    public float stopDistance = 0.5f; // Distance to stop from the player
    public float chaseDelay = 10f; // Delay before chasing starts
    private Transform myTransform; // current transform data of this enemy
    private Rigidbody rb; // Reference to the Rigidbody component
    private bool isChasing = false; // Whether the enemy is currently chasing the player

    void Awake()
    {
        target = GameObject.FindWithTag("Player").transform; // target the player
        myTransform = transform; // cache transform data for easy access/performance
        rb = GetComponent<Rigidbody>(); // get the Rigidbody component
        if (rb == null)
        {
            Debug.LogError("Rigidbody component not found on " + gameObject.name);
        }

        StartCoroutine(StartChaseAfterDelay()); // Start the coroutine to delay the chase
    }

    IEnumerator StartChaseAfterDelay()
    {
        yield return new WaitForSeconds(chaseDelay); // Wait for the specified delay
        isChasing = true; // Allow the enemy to start chasing
    }

    void FixedUpdate()
    {
        if (isChasing) // Only chase if the delay has passed
        {
            float distance = Vector3.Distance(myTransform.position, target.position);
            if (distance <= range)
            {
                if (distance > stopDistance)
                {
                    // Look at the player and move towards them
                    Vector3 direction = (target.position - myTransform.position).normalized;
                    Quaternion lookRotation = Quaternion.LookRotation(direction);
                    myTransform.rotation = Quaternion.Slerp(myTransform.rotation, lookRotation, rotationSpeed * Time.deltaTime);

                    rb.MovePosition(myTransform.position + myTransform.forward * moveSpeed * Time.deltaTime);
                }
                else
                {
                    // Stop moving and rotating completely if within stop distance
                    rb.velocity = Vector3.zero;
                    rb.angularVelocity = Vector3.zero; // Stop any residual rotation
                }
            }
            else
            {
                // Ensure the enemy stops moving if the player is out of range
                rb.velocity = Vector3.zero;
                rb.angularVelocity = Vector3.zero; // Stop any residual rotation
            }
        }
    }
}