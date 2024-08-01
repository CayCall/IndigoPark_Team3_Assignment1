using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gearsInventory : MonoBehaviour
{
  
    [SerializeField] public Gears[] gearsController;

    private void Awake()
    {
        gearsController = new Gears[0];
    }
}