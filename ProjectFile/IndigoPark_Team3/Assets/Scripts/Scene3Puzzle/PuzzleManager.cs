using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleManager : MonoBehaviour
{

    public int shapeCounter = 0;
    private HashSet<string> collidedIdentifiers = new HashSet<string>();

    [SerializeField] private GameObject door;

    public Animator doorAnim;
    public AudioSource chimeSound;

    public void IncrementShapeCounter(string boxIdentifier)
    {
        if (!collidedIdentifiers.Contains(boxIdentifier))
        {
            collidedIdentifiers.Add(boxIdentifier);
            shapeCounter++;
            Debug.Log($"Puzzle Shape Counter updated. New count: {shapeCounter}");
            if (collidedIdentifiers.Count == 1)
            {
                doorAnim.SetTrigger("FirstDoor");
                chimeSound.Play();
            }
            if (collidedIdentifiers.Count == 5)
            {
                OpenDoor();
            }
        }
    }

    private void OpenDoor()
    {
        if (door != null)
        {
            door.SetActive(false);
            Debug.Log("Door opened!");
        }
    }
}