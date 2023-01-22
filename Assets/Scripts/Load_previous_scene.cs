using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Load_previous_scene : MonoBehaviour
{

    public Button button;
    // Start is called before the first frame update
    void Start()
    {
        button.onClick.AddListener(LoadMasterScene);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void LoadMasterScene()
    {
        SceneManager.LoadScene(0);
    }

}
