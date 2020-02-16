using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Highscore : MonoBehaviour
{
    private Text s_Text;
    private int score = 0;

    

    // Start is called before the first frame update
    void Start()
    {
        s_Text = GameObject.Find("ScoreText").GetComponent<Text>();
        InvokeRepeating("ScoreSeconds", 0.1f, 0.1f);
        
    }

    // Update is called once per frame
    void Update()
    {
        s_Text.text = "Score: " + score.ToString();
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
}
