using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Scene1UIManager : MonoBehaviour
{
    public GameObject Info;
    public TMP_Text Task;

    private void Start()
    {
        StartCoroutine(Removetext());
    }
    private void Update()
    {
        
    }

    IEnumerator Removetext()
    {
        yield return new WaitForSeconds(5.0f);
        Info.SetActive(false);
    }
}
