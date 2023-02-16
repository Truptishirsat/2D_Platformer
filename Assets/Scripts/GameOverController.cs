using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverController : MonoBehaviour
{
    public Button button;
    private void Awake()
    {
        button.onClick.AddListener(ReloadScene);
    }

    public void OnPlayerDie()
    {
        gameObject.SetActive(true);
       
    }

    private void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    } 
}
