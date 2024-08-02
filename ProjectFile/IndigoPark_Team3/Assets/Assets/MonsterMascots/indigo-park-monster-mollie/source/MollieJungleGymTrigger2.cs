using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MollieJungleGymTrigger2 : MonoBehaviour
{
    public GameObject Mollie;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(Mollie);
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
