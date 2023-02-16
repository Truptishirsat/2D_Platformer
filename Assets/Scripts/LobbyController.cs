using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LobbyController : MonoBehaviour
{
   public Button buttonPlay;

   private void Awake()
   {
        buttonPlay.onClick.AddListener(LoadGame);
   }

    private void LoadGame()
    {
        SceneManager.LoadScene(1);
    }
}
