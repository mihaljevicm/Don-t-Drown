using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine;
using UnityEngine.UI;


public class GameManager : MonoBehaviour {

    public static GameManager gm;

    public Text TimerText;
    public Text PlatformCounter;
    
    private int platformCounter = 0;
    private float timer = 0.0f; 

    void Awake()
    {
        if(gm == null)          //singleton pattern
        {
            gm = this;
        }
        else
        {
            Destroy(gameObject);   //destroy GameManager if there is alredy 
        }
    }

    void Update()
    {
        if(CrossPlatformInputManager.GetButtonDown("Cancel"))
            {
                Application.Quit();
            }
        ChangeTime(Time.deltaTime);
    }
  
    public void ChangeTime(float amount)
    {
        timer += amount;
        TimerText.text = "Timer : " + timer.ToString();
    }

    public void PlatformCount(int amount)
    {
        platformCounter+=amount;
        PlatformCounter.text = "Switched platforms: " + platformCounter.ToString();
    }

    public void SaveScore()
    {
        PlayerPrefs.SetInt("score", platformCounter);
    }

    public void LoadScene(int index)
    {
        //0 - Main scene
        //1 - Game scene
        //2 - Game over 
        switch (index)
        {
            case 0:
                {
                    SceneManager.LoadScene(index);
                    break;
                }
            case 1:
                {
                    SceneManager.LoadScene(index);
                    break;
                }
            case 2:
                {
                    SceneManager.LoadScene(index);
                    break;
                }
            case 3:
                {
                    Application.Quit();
                    break;
                }
            default:
                {
                    SceneManager.LoadScene(0);
                    break;
                }
        }
    }
}
