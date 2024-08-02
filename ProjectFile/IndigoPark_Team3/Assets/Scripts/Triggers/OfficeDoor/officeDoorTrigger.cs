using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class officeDoorTrigger : MonoBehaviour
{
    [SerializeField] private Animator ani;
    [SerializeField] private bool PlayerFound;
    private AudioSource _doorSound;
    private void Start()
    {
        _doorSound = GameObject.Find("01_low").GetComponent<AudioSource>();
        ani = GameObject.Find("01_low").GetComponent<Animator>();
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerFound = true;
            _doorSound.Play();
        }
        
        if (PlayerFound)
        {
            ani.SetInteger("Animstate", 1);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerFound = false;
        }

        if (PlayerFound == false)
        {
            ani.SetInteger("Animstate", 2);
        }
    }
}