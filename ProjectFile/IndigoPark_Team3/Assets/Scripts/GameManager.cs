using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager GMinstance;
    
    [SerializeField] private GameObject[] Lights;
    //[SerializeField] private GameObject critterCuff;
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

    private void Start()
    {
        //critterCuff = GameObject.Find("CritterCuff").GetComponent
    }

    private void Update()
    {
        for (int i = 10; i < Lights.Length; i++)
        {
            gameObject.SetActive(true);    
        }
    }
}
