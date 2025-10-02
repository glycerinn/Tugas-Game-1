using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameOverScreen : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI FinalScoreText;
    [SerializeField] TextMeshProUGUI CurrentScore;
    public AudioSource mySource;
    public AudioClip myClip;


    void Start()
    {

    }

    public void SetUp()
    {
        gameObject.SetActive(true);
        FinalScoreText.text = CurrentScore.text;
        CurrentScore.gameObject.SetActive(false);
    }

    public void PlayAgain()
    {
        Click();
        SceneManager.LoadScene("PlayScene");
    }

    public void BacktoMenu()
    {
        Click();
        SceneManager.LoadScene("MainMenu");
    }
    
    public void Click()
    {
        mySource.clip = myClip;
        mySource.Play();
    }
}
