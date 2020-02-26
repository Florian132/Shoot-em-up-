using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Highscore : MonoBehaviour
{
    private Text s_Text;
    private int score = 0;

    private int highScore;
    // Start is called before the first frame update
    void Start()
    {

        s_Text = GameObject.Find("ScoreText").GetComponent<Text>();
        InvokeRepeating("ScoreSeconds", 0.1f, 0.1f);

        DontDestroyOnLoad(gameObject);
        highScore = loadHighScore();
    }
    // Update is called once per frame
    void Update()
    {
        s_Text.text = "Score " + System.Environment.NewLine + score.ToString();
        if (Input.GetKeyDown(KeyCode.M))
        {
            resetHighScore();
        }
    }

    //Adds 10 score every second
    void  ScoreSeconds()
    {
        score = score + 1;
    }

    public void addScore(int enemyScore)
    {
        score = score + enemyScore;
    }
    public int GetScore()
    {
        return score;
    }
    public void newHighScoreCheck()
    {
        if (score > highScore)
        {
            saveHighScore();
        }
        saveYourScore();
    }

    public void saveYourScore()
    {
        PlayerPrefs.SetInt("YourScore", score);
    }
    public int loadYourScore()
    {
        return PlayerPrefs.GetInt("YourScore", score);
    }
    public void saveHighScore()
    {
        PlayerPrefs.SetInt("HighScore", score);
    }
    public int loadHighScore()
    {
        return PlayerPrefs.GetInt("HighScore");
    }
    public void resetHighScore()
    {
        PlayerPrefs.SetInt("HighScore", 0);
    }
}
