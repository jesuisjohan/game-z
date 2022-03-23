using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu_Manager : MonoBehaviour
{
    public void StartGame() {
        SceneManager.LoadScene(0, LoadSceneMode.Single);
    }
    public void ExitGame() {
        Application.Quit();
    }
}
