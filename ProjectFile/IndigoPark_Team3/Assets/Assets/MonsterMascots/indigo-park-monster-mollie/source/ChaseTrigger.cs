using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseTrigger : MonoBehaviour
{
    public GameObject Enemy;
    public AudioSource Scream;
    [SerializeField] Animator ani;
    public AudioSource Music;
    private void OnTriggerEnter(Collider other)
    {
       if (other.CompareTag("Player"))
        {
            Enemy.SetActive(true);
            Scream.Play();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ani.SetInteger("EnemyState",1);
            Music.Play();
            this.gameObject.SetActive(false);
        }
    }
}
