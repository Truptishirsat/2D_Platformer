using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Button))]
public class SceneLoader : MonoBehaviour
{
    private Button button;


    public string levelName;
    void Awake()
    {
        button = gameObject.GetComponent<Button>();
        button.onClick.AddListener(LoadLevel);
    }

    private void LoadLevel()
    {   
        LevelStatus levelStatus = LevelManager.Instance.GetLevelStatus(levelName);

        switch(levelStatus)
        {
            case LevelStatus.Locked:
                Debug.Log("Can't play this level until you unlock it!");
                break;
            
            case LevelStatus.Unlocked:
                SceneManager.LoadScene(levelName);
                break;

            case LevelStatus.Completed:
                SceneManager.LoadScene(levelName);
                break;
        }
    }
}
