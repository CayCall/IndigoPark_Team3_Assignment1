using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventTriggerController : MonoBehaviour
{
    public void PlayAudio(AudioSource source, AudioClip clip)
    {
        source.clip = clip;
        source.Play();
    }

    public void PlayParticle(ParticleSystem particleSystem)
    {
        particleSystem.Play();
    }

    public void ShowUI(GameObject uiElement)
    {
        uiElement.SetActive(true);
    }

    public void OpenDoor(Animator animator)
    {
        animator.SetTrigger("Open");
    }

    public void ActivateObjects(GameObject[] objects)
    {
        foreach (var obj in objects)
        {
            obj.SetActive(true);
        }
    }

    public void EnableLights(Light[] lights)
    {
        foreach (var light in lights)
        {
            light.enabled = true;
        }
    }
}