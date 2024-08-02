using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndChase : MonoBehaviour
{
    public AudioSource Music;
    public GameObject Mollie;
    public GameObject Door;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Music.Stop();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Door.SetActive(true);
            Destroy(Mollie);
        }
    }
}
