using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DestroyLloyd : MonoBehaviour
{
    public GameObject LloydModel;

    public IEnumerator Destroyed()
    {
        yield return new WaitForSeconds(5.0f);
        Destroy(LloydModel);
    }


}
