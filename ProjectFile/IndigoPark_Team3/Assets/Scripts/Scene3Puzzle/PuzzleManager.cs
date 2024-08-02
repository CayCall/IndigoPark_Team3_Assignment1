using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleManager : MonoBehaviour
{
    public int shapeCounter = 0;
    public GameObject door; // Reference to the door GameObject

    private HashSet<string> collidedIdentifiers = new HashSet<string>(); // Track collided identifiers
    private HashSet<string> allIdentifiers = new HashSet<string>(); // Track all required identifiers

    private void Start()
    {
        // Initialize allIdentifiers with the required box identifiers
        // For demonstration purposes, you can set these manually or dynamically
        allIdentifiers.Add("Star");
        allIdentifiers.Add("Square");
        allIdentifiers.Add("Star");
        allIdentifiers.Add("Triangle");
        allIdentifiers.Add("Circle");
    }

    public void IncrementShapeCounter(string boxIdentifier)
    {
        // Increment the shape counter
        shapeCounter++;
        Debug.Log($"Puzzle Shape Counter updated. New count: {shapeCounter}");

        // Add the boxIdentifier to the collidedIdentifiers set
        if (allIdentifiers.Contains(boxIdentifier))
        {
            collidedIdentifiers.Add(boxIdentifier);
            CheckAllIdentifiersCollided();
        }
    }

    private void CheckAllIdentifiersCollided()
    {
        // Check if all required identifiers have collided
        if (collidedIdentifiers.SetEquals(allIdentifiers))
        {
            OpenDoor();
        }
    }

    private void OpenDoor()
    {
        // Implement the door opening logic here
        if (door != null)
        {
            door.SetActive(false);
            Debug.Log("Door opened!");
        }
    }
}