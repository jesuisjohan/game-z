using UnityEngine;
using UnityEngine.SceneManagement;

public class SettingGameMenu : MonoBehaviour
{
    public int MainMenu;
    public void ReturnToMainMenu() {
        SceneManager.LoadScene(MainMenu, LoadSceneMode.Single);
    }
    public void StartGame() {
        return;
    }
    public void ExitGame() {
        Application.Quit();
    }
}
