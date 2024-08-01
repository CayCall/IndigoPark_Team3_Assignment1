using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    [SerializeField] private Animator ani;
    [SerializeField] private bool PlayerFound;
    private AudioSource _doorSound;
    private void Start()
    {
        _doorSound = GameObject.Find("OfficeDoor_Trigger").GetComponent<AudioSource>();
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
            ani.SetInteger("AnimState", 1);
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
            ani.SetInteger("AnimState", 2);
        }
    }
}
