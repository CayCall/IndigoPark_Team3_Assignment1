using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Scene1UIManager : MonoBehaviour
{
    public GameObject Info;

    private void Start()
    {
        StartCoroutine(Removetext());
    }
    private void Update()
    {
        
    }

    IEnumerator Removetext()
    {
        yield return new WaitForSeconds(3.0f);
        Info.SetActive(false);
    }
}
