using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeathScore : MonoBehaviour
{
    public Text yourScoreText;
    public Text highScoreText;

    Highscore highscore;
    // Start is called before the first frame update
    void Start()
    {
        highscore = GameObject.FindObjectOfType<Highscore>();
        yourScoreText.text = "Final score: " + highscore.loadYourScore().ToString();
        highScoreText.text = "High score: " + highscore.loadHighScore().ToString();


    }

    // Update is called once per frame
    void Update()
    {

    }
}
