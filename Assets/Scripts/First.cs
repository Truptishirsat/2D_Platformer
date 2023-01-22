using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class First : MonoBehaviour
{
    public string scene1;
    public string scene2;
    public string scene3;

    public Button button1;
    public Button button2;
    public Button button3;

    void Start()
    {
         button1.onClick.AddListener(LoadScene1);
        button2.onClick.AddListener(LoadScene2);
        button3.onClick.AddListener(LoadScene3);
    }

    void Update()
    {
       
    }

    void LoadScene1()
    {
        SceneManager.LoadScene(scene1);
    }
    void LoadScene2()
    {
        SceneManager.LoadScene(scene2);
    }

    void LoadScene3()
    {
        SceneManager.LoadScene(scene3);
    }
}
