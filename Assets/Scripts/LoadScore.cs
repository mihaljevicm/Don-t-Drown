using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadScore : MonoBehaviour {

    private int score = 0;
    public Text ScoreText;

    private void Awake()
    {
        score = PlayerPrefs.GetInt("score"); //load score
        ScoreText.text = "Score: " + score.ToString(); //print score in text
    }
}
