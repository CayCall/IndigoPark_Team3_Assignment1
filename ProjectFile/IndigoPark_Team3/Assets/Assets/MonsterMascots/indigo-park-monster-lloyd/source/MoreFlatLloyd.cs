using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoreFlatLloyd : MonoBehaviour
{
    public DestroyLloyd Lloyd;
    public GameObject Destroyer;

    private void Start()
    {
        Lloyd = Destroyer.GetComponent<DestroyLloyd>();
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Lloyd.StartCoroutine(Lloyd.Destroyed());
            this.gameObject.SetActive(false);
        }
    }


}
