using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MollieMovement : MonoBehaviour
{
    public GameObject Flash;
    public GameObject Mollie;


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Mollie.SetActive(true);
            StartCoroutine(MollieScare());
        }
    }

    IEnumerator MollieScare()
    {
        yield return new WaitForSeconds(3.0f);
        Flash.SetActive(false);
        StartCoroutine(FixFlashlight());
        Mollie.SetActive(false);


    }

    IEnumerator FixFlashlight()
    {
        yield return new WaitForSeconds(1.0f);
        Flash.SetActive(true);
        this.gameObject.SetActive(false);
    }
}
