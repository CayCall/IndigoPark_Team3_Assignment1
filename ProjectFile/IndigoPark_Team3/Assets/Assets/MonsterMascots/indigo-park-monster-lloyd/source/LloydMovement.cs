using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LloydMovement : MonoBehaviour
{
    [SerializeField] private Animator ani;
    public DestroyLloyd Lloyd;
    public GameObject Destroyer;

    private void Start()
    {
        Lloyd = Destroyer.GetComponent<DestroyLloyd>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ani.SetInteger("LloydState", 1);
        }
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
