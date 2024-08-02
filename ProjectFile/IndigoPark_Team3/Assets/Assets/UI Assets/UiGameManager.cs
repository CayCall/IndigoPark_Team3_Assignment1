using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UiGameManager : MonoBehaviour
{
    public GameObject PauseScreen;
    public string SceneName;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale = 0f;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            PauseScreen.SetActive(true);
        }
    }
    public void ReturnToStart()
    {
        SceneManager.LoadScene(SceneName);
    }

    public void ResumeGame()
    {
        PauseScreen.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Time.timeScale = 1.0f;
    }

}
