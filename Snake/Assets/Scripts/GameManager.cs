using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    /*public Text scoreText;
    public Text hScoreText;
    public int score;
    public int hScore;*/
    public GameObject gameOverPanel;

    /*public void SetScore(int value)
    {
        score += value;
        scoreText.text = "score: " + score.ToString();
    }*/

    public void GamerOver()
    {
        gameOverPanel.SetActive(true);
        /*if(score > hScore)
        {
            PlayerPrefs.SetInt("hScore", score);
            hScoreText.text = "New H-score" + score.ToString();
        }*/
        Time.timeScale = 0;
    }
}
