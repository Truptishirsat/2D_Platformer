using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthController : MonoBehaviour
{
    public static int health = 3;

    public Image[] hearts;
    public Sprite emptyheart;
    public Sprite fullheart;

    private void Start()
    {
        health = 3;
    }
    private void Update()
    {
        foreach(Image img in hearts)
        {
            img.sprite = emptyheart;
        }
        for (int i = 0; i < health; i++)        
        {
            hearts[i].sprite = fullheart;
        }
    }
}
