using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("PlayLevel");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
