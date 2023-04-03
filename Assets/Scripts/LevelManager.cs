
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
   
   private static LevelManager instance;
   public static LevelManager Instance {get { return instance;}}
   public string[] levels;

   private void Awake()
   {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

   }

    private void Start()
    {
        if(GetLevelStatus(levels[0]) == LevelStatus.Locked)
        {
            SetLevelStatus(levels[0], LevelStatus.Unlocked);
        }
    }

    public void MarkCurrentLevelComplete()
    {
        // set current scene to complete levelstatus
        
        Scene currentScene = SceneManager.GetActiveScene();
        SetLevelStatus(currentScene.name, LevelStatus.Completed);

        // set next scene to unlock levelstatus
        /*
        int nextSceneBuildIndex = currentScene.buildIndex + 1;
        Scene nextScene = SceneManager.GetSceneByBuildIndex(nextSceneBuildIndex);
        SetLevelStatus(nextScene.name, LevelStatus.Unlocked);*/

        int nextSceneIndex = Array.FindIndex(levels,  level => level == currentScene.name) + 1;

        if(nextSceneIndex < levels.Length)
        {
            SetLevelStatus(levels[nextSceneIndex],LevelStatus.Unlocked);
        }

    }
   public LevelStatus GetLevelStatus(string level)
   {
        LevelStatus levelstatus = (LevelStatus)PlayerPrefs.GetInt(level, 0);
        return levelstatus;
   }

   public void SetLevelStatus(string level, LevelStatus levelStatus)
   {
        PlayerPrefs.SetInt(level, (int)levelStatus);
        Debug.Log("setting level: " + level + " " + "status: "+ levelStatus);
   }
}
