using UnityEngine;

public class FlatLloydTrigger : MonoBehaviour
{
    [SerializeField] private Animator ani;
    public GameObject Box;
    public GameObject FlatLloyd;
    public AudioSource Crash;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            FlatLloyd.SetActive(true);
            Crash.Play();
            ani.SetInteger("BoxState",1);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            this.gameObject.SetActive(false);
        }
    }
}
