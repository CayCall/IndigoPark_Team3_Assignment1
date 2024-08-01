using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager GMinstance;
    
    //Scene 1
    [SerializeField] public GameObject[] Lights;
    [SerializeField]  public GearsController[] gearsController;
    //[SerializeField] private GameObject critterCuff;
    [SerializeField] private Generator Gen;
    
    
    //Scene 2
    
    private void Awake()
    {
        if (GMinstance == null)
        {
            GMinstance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    //Scene 1
    private void startGenerator()
    {
        Gen.GeneratorStart();           
    }
    
    
    //Scene 2
    
    
}
