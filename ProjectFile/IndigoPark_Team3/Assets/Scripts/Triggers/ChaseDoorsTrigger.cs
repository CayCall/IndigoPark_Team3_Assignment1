using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseDoorsTrigger : MonoBehaviour
{
    public GameObject Doors;
    public bool PlayerFound;
    private void Update()
    {
        if (PlayerFound)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                Doors.SetActive(false);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerFound = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerFound = false;
        }
    }
}
