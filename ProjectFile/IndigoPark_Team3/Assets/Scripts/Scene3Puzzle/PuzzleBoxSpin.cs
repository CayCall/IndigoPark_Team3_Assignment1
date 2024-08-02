using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleBoxSpin : MonoBehaviour
{
    [SerializeField] private string boxIdentifier; // Unique identifier for each box
    [SerializeField] private PuzzleManager puzzleManager; // Reference to PuzzleManager

    // Rotation amount in degrees
    public float rotationAmount = 90f;
    public float rotationDuration = 1f;  // Duration of the rotation in seconds

    private float currentYRotation;
    private bool isRotating = false;

    void Start()
    {
        // Ensure PuzzleManager is assigned
        if (puzzleManager == null)
        {
            puzzleManager = GameObject.Find("PuzzleManager").GetComponent<PuzzleManager>();
        }
        currentYRotation = transform.localRotation.eulerAngles.y;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R) && !isRotating)
        {
            StartCoroutine(RotateObject());
        }
    }

    IEnumerator RotateObject()
    {
        isRotating = true;
        
        float targetYRotation = currentYRotation + rotationAmount;
        Quaternion startRotation = transform.localRotation;
        Quaternion endRotation = Quaternion.Euler(startRotation.eulerAngles.x, targetYRotation, startRotation.eulerAngles.z);

        float elapsedTime = 0f;
        
        while (elapsedTime < rotationDuration)
        {
            transform.localRotation = Quaternion.Slerp(startRotation, endRotation, elapsedTime / rotationDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        
        transform.localRotation = endRotation;
        
        currentYRotation = targetYRotation;

        isRotating = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PuzzleShapeCounter"))
        {
            puzzleManager.IncrementShapeCounter(boxIdentifier);
            Debug.Log($"Box {boxIdentifier} collided");
        }
    }
}
 

