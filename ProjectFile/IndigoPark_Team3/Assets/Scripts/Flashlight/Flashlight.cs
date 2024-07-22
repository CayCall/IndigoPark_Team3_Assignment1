using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour
{
    public GameObject lightObject;  
    private bool isOn = false;

    void Start()
    {
        if (lightObject == null)
        {
            Debug.LogError("No light GameObject assigned.");
        }
        else
        {
            lightObject.SetActive(isOn);  
        }
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) 
        {
            ToggleLight();
        }
    }

    private void ToggleLight()
    {
        isOn = !isOn;
        lightObject.SetActive(isOn);
    }
}
