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
        SoundManager.Instance.Play(Sounds.GameOver);
       
    }

    private void ReloadScene()
    {
        SoundManager.Instance.Play(Sounds.ButtonClick);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    } 


    private void LoadLobby()
    {
        SoundManager.Instance.Play(Sounds.ButtonClick);
        
        SceneManager.LoadScene("Lobby");
        gameObject.SetActive(false);

    }
}
