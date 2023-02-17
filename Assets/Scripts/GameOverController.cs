using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverController : MonoBehaviour
{
    public Button buttonRestart;
    public Button buttonLobby;
    private void Awake()
    {
        buttonRestart.onClick.AddListener(ReloadScene);
        buttonLobby.onClick.AddListener(LoadLobby);
    }

    public void OnPlayerDie()
    {
        gameObject.SetActive(true);
       
    }

    private void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    } 


    private void LoadLobby()
    {
        gameObject.SetActive(false);
        
        SceneManager.LoadScene("Lobby");
    }
}
