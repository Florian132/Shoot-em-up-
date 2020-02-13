using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Highscore : MonoBehaviour
{
    private Text s_Text;
    private string scoreText;
    private int score = 0;


    // Start is called before the first frame update
    void Start()
    {
        s_Text = GameObject.Find("ScoreText").GetComponent<Text>();
        InvokeRepeating("ScoreSeconds", 0f, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        scoreText = score.ToString();
        s_Text.text = "Score: " + score;
    }

    //Adds 10 score every second
    void  ScoreSeconds()
    {
        score = score + 10;
    }
}
