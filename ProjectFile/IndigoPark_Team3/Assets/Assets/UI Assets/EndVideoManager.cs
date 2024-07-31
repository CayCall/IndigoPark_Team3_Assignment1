using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Video;

public class EndVideoManager : MonoBehaviour
{
    public GameObject Video;
    public GameObject VideoPanel;
    public GameObject EndScreen;

    public bool VideoSkip = false;

    private void Update()
    {
        if (VideoSkip == false)
        {
            StartCoroutine(VideoTime());
        }
    }
    IEnumerator VideoTime()
    {
        yield return new WaitForSeconds(188f);
        VideoPanel.SetActive(false);
        Video.SetActive(false);
        EndScreen.SetActive(true);
    }

    public void SkipVideo()
    {
        VideoSkip = true;
    }

}
