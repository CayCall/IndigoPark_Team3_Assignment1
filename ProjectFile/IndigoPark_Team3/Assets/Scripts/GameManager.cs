using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager GMinstance;
    

    [SerializeField] public GameObject[] Lights;
    [SerializeField] private Generator Gen;

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
        Gen = GameObject.Find("minigenerator").GetComponent<Generator>();
    }

    private void Update()
    {
        // Your existing update logic if any
    }
}