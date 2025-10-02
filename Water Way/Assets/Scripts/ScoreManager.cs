using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI MyScore;
    public int Score;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Score = 0;
        MyScore.text = "Score: " + Score.ToString();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void AddScore(int amount)
    {
        Score += amount;
        MyScore.text = "Score: " + Score.ToString();
    }
}
