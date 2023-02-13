using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ScoreController : MonoBehaviour
{
    private int score_value = 0;
    private TextMeshProUGUI score_text;

    private void Awake()
    {
        score_text = gameObject.GetComponent<TextMeshProUGUI>();
    }
    private void Start()
    {
        RefreshUI();
    }
    public void IncrementScore(int increment)
    {
        score_value += increment;
        RefreshUI();
    }

    private void RefreshUI()
    {
        score_text.text = "Score: " + score_value;
    }
}
