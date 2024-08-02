using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CritterPickUp : MonoBehaviour
{

    public GameObject CritterCuff;
    public GameObject Text;
    public GameObject block;
    public GameObject CritterUI;
    private bool playerInTrigger = false;

    // Start is called before the first frame update
    void Start()
    {
        CritterCuff.SetActive(true);
        Text.SetActive(false);
        block.SetActive(true);
        CritterUI.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Text.SetActive(true);
            playerInTrigger = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Text.SetActive(false);
            playerInTrigger = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (playerInTrigger && Input.GetKeyDown(KeyCode.F))
        {
            CritterUI.SetActive(true);
            CritterCuff.transform.position += new Vector3(0, -1, 0);
            Text.transform.position += new Vector3(0, -10, 0);
            Text.SetActive(false);
            Destroy(block);
        }
    }
}
