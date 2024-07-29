using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SurvCamBehaviour : MonoBehaviour
{
    public Transform player; 
    public float rotationSpeed = 5f; 
    void Update()
    {
        if (player != null)
        {
            Vector3 directionToPlayer = player.position - transform.position;
            Quaternion targetRotation = Quaternion.LookRotation(directionToPlayer);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }
    }
}