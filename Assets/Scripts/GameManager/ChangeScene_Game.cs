using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene_Game : MonoBehaviour
{
    public void StartGame() {
        SceneManager.LoadScene(0, LoadSceneMode.Single);
    }
    public void BackToHome() {
        SceneManager.LoadScene(1, LoadSceneMode.Single);
    }
}
