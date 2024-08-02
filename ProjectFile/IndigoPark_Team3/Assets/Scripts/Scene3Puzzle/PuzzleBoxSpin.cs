using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleBoxSpin : MonoBehaviour
{
    [SerializeField] private string boxIdentifier; 
    private PuzzleManager puzzleManager;
    
    // Rotation amount in degrees
    public float rotationAmount = 90f;
    public float rotationDuration = 1f;  

    private float currentYRotation;
    private bool isRotating = false;

    void Start()
    {
        puzzleManager = GameObject.Find("PuzzleManager").GetComponent<PuzzleManager>();
        currentYRotation = transform.localRotation.eulerAngles.y;
    }

    public void StartRotation()
    {
        if (!isRotating)
        {
            StartCoroutine(RotateObject());
        }
    }

    public bool IsRotating()
    {
        return isRotating;
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
            GetComponent<Collider>().enabled = false;
        }
    }
}