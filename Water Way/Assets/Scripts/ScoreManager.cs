using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI MyScore;
    public TextMeshProUGUI MyHighScore;
    public int Score;
    public int HighScoreScore;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        HighScoreScore = PlayerPrefs.GetInt("HighScore", 0);
        Score = 0;
        MyScore.text = "Score: " + Score.ToString();
        MyHighScore.text = "HighScore: " + HighScoreScore.ToString();
    }

    public void AddScore(int amount)
    {
        Score += amount;
        MyScore.text = "Score: " + Score.ToString();
        CheckHighScore();
    }

    void CheckHighScore()
    {
        if (Score > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", Score);
        }
    }
}
