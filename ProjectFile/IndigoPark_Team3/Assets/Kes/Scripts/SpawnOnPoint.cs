using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnOnPoint : MonoBehaviour
{
    public Transform teleportPoint; // Transform to teleport the player to
    private CharacterController characterController;

    private void Start()
    {
        // Get the CharacterController component
        characterController = GetComponent<CharacterController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        // Log the tag of the object that triggered the collision
        Debug.Log("Collided with: " + other.tag);

        if (other.CompareTag("Teleporter"))
        {
            // Log the teleportation action for debugging
            Debug.Log("Teleporting to: " + teleportPoint.position);

            // Ensure teleportation point is valid
            if (teleportPoint != null)
            {
                // Log current player position
                Debug.Log("Current position: " + transform.position);

                // Teleport the player to the specified teleportPoint
                // Use the CharacterController's Move method to update position
                Vector3 newPosition = teleportPoint.position;
                characterController.enabled = false; // Disable CharacterController to avoid interference
                transform.position = newPosition; // Set the position
                characterController.enabled = true; // Re-enable CharacterController
                Debug.Log("New position: " + transform.position);
            }
            else
            {
                Debug.LogError("Teleport point is not assigned!");
            }
        }
    }
}
