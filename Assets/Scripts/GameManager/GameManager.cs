
// using System.Threading;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static GameManager instance;
    public bool endGame;
    public GameObject pnlEndGame;
    public GameObject pnlWinGame;
    AudioSource backgroundSound;
    private void Awake() {
        endGame = false;
        pnlEndGame.SetActive(false);
        pnlWinGame.SetActive(false);
        if(instance == null)
            instance = this;
    }
    
    private void Start() {
        backgroundSound = gameObject.GetComponent<AudioSource>();
        backgroundSound.volume = PlayerPrefs.GetFloat("volume", 1);
    }
  
    public void GameOver(){
        Debug.Log("LOSE");
        endGame = true;
        pnlEndGame.SetActive(true);
    }
    public void RePlay()
    {
        SceneManager.LoadScene("Main");
    }
    public void Home()
    {
        SceneManager.LoadScene("StarMenu");
    }
    public void WinGame()
    {
        pnlWinGame.SetActive(true);
    }
    // }

}
