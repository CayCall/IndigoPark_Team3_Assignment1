using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public string SceneName;
    public void QuitGame()
    {
        Application.Quit();
    }

    public void NewScene()
    {
        SceneManager.LoadScene(SceneName);
    }

}
