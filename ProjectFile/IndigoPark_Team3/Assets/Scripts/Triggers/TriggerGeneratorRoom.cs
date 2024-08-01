using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TriggerGeneratorRoom : MonoBehaviour
{
    [SerializeField] private Animator ani;
    [SerializeField] private bool PlayerFound;
    [SerializeField] private GameObject Gears;

 

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerFound = true;      
            Gears.SetActive(true);
        }
        if (PlayerFound)
        {
            ani.SetInteger("AnimState", 1);
        }

    
    }
}
