using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreText : MonoBehaviour
{
    private Text fs_Text;
    private int score;

    Highscore highscore;

    // Start is called before the first frame update
    void Start()
    {
        highscore = GameObject.FindObjectOfType<Highscore>();
        fs_Text = GameObject.Find("ScoreText").GetComponent<Text>();

        score = highscore.GetScore();

        
    }

    // Update is called once per frame
    void Update()
    {
        fs_Text.text = "Final score: " + score.ToString();
    }
}
