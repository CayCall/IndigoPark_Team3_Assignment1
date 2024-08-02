using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MollieJungleGym : MonoBehaviour
{
    public GameObject Mollie;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Mollie.SetActive(true);
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
