using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopObj : MonoBehaviour
{

    public GameObject text;

    private bool playerInTrigger = false;

    // Start is called before the first frame update
    void Start()
    {
        text.SetActive(true);

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            text.SetActive(false);
            playerInTrigger = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            text.SetActive(false);
            playerInTrigger = false;
        }
    }
}
