using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConfigurableTrigger : MonoBehaviour
{
     public enum EventType { IntroduceRumbley, InteractWithRumbley, GoToMainGate, StartGenerator, OpenMainDoor, ReceiveCritterCuff }
    public EventType currentEvent;

    public EventTriggerController triggerEvent;

    private AudioSource audioSource;
    public AudioClip audioClip; // Add this line
    public ParticleSystem particleSystem;
    public GameObject uiElement;
    public Animator doorAnimator;
    public GameObject[] gears;
    public Light[] lights;

    public void Awake()
    {
        GetRefs();     
    }

    public void GetRefs()
    {
        audioSource = GameObject.Find("Main Camera").GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            switch (currentEvent)
            {
                case EventType.IntroduceRumbley:
                    triggerEvent.PlayAudio(audioSource, audioClip); // Modified to pass audioClip
                    triggerEvent.PlayParticle(particleSystem);
                    break;

                case EventType.InteractWithRumbley:
                    triggerEvent.PlayAudio(audioSource, audioClip); // Modified to pass audioClip
                    break;

                case EventType.GoToMainGate:
                    triggerEvent.ShowUI(uiElement);
                    triggerEvent.PlayAudio(audioSource, audioClip); // Modified to pass audioClip
                    triggerEvent.OpenDoor(doorAnimator);
                    break;

                case EventType.StartGenerator:
                    triggerEvent.ActivateObjects(gears);
                    triggerEvent.PlayAudio(audioSource, audioClip); // Modified to pass audioClip
                    triggerEvent.EnableLights(lights);
                    break;

                case EventType.OpenMainDoor:
                    triggerEvent.PlayAudio(audioSource, audioClip); // Modified to pass audioClip
                    triggerEvent.OpenDoor(doorAnimator);
                    break;

                case EventType.ReceiveCritterCuff:
                    triggerEvent.PlayAudio(audioSource, audioClip); // Modified to pass audioClip
                    triggerEvent.OpenDoor(doorAnimator);
                    break;

                default:
                    break;
            }
        }
    }
}