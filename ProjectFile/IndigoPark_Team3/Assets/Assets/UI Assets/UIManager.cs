using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public string SceneName;
    private void QuitGame()
    {
        Application.Quit();
    }

    private void NewScene()
    {
        SceneManager.LoadScene(SceneName);
    }

}
