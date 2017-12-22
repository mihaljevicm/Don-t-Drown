using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadScore : MonoBehaviour {

    private int score = 0;
    public Text ScoreText;

    private void Awake()
    {
        score = PlayerPrefs.GetInt("score");
        ScoreText.text = "Score: " + score.ToString();
    }
}
