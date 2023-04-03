using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelCompleteUIController : MonoBehaviour
{
   public Button nextlevel;
   public Button Quit;

    private void Awake()
    {
        nextlevel.onClick.AddListener(LoadNextScene);
        Quit.onClick.AddListener(LoadLobby);
    }

    private void LoadNextScene()
    {   
        SoundManager.Instance.Play(Sounds.ButtonClick);
        int index = SceneManager.GetActiveScene().buildIndex + 1;
        SceneManager.LoadScene(index);
    }

    private void LoadLobby()
    {
        SoundManager.Instance.Play(Sounds.ButtonClick);

        SceneManager.LoadScene("Lobby");
    }

}
