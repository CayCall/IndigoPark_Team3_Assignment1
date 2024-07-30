using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioTrigger : MonoBehaviour
{
    public string audioIdentifier;
    private bool hasBeenTriggered = false;

    private void OnTriggerEnter(Collider other)
    {
        if (!hasBeenTriggered && other.CompareTag("Player"))
        {
            AudioManager.instance.PlayAudio(audioIdentifier);
            hasBeenTriggered = true;
            DisableTrigger();
        }
    }

    private void DisableTrigger()
    {
        GetComponent<BoxCollider>().enabled = false;
    }
}