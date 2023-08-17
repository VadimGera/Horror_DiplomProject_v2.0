using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadSceneAsync("StartGameCutScene");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
