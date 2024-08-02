using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackstageMovement : MonoBehaviour
{
    public GameObject BackstageLloyd;
    public AudioSource LloydNoises;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            BackstageLloyd.SetActive(true);
            LloydNoises.Play();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            this.gameObject.SetActive(false);
        }
    }
}
