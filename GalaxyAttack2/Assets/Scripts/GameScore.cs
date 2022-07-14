using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameScore : MonoBehaviour
{
    Text ScoreText; 

    int score;

    public int Score
    {
        get {
            return this.score; 
        }
        set 
        {
            this.score = value; 
            UpdateScoreTextUI();
        }
    }
    
    // Start is called before the first frame update
    void Start()
    {
        ScoreText = GetComponent<Text>();
    }

    void UpdateScoreTextUI()
    {
        string scoreStr = string.Format("{0:00000}", score);
        ScoreText.text = scoreStr; 
    }

}
