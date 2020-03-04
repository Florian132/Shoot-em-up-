using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreText : MonoBehaviour
{
    private Text fs_Text;
    private int score = 0;

    // Start is called before the first frame update
    void Start()
    {
        fs_Text = GameObject.Find("ScoreText").GetComponent<Text>();
        
    }

    // Update is called once per frame
    void Update()
    {
        fs_Text.text = "Final score: " + score.ToString();
    }
}
