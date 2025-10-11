using TMPro;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public AudioSource mySource;
    public AudioClip myClip;
    int TotalCoins;
    public TextMeshProUGUI TotalCoinsText;
    public SettingsManager settingsManager;
   

    void Start()
    {
        TotalCoins = PlayerPrefs.GetInt("TotalCoin", 0);
        TotalCoinsText.text = TotalCoins.ToString();
    }

    public void PlayGame()
    {
        Click();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void GoToShop()
    {
        Click();
        SceneManager.LoadScene("ShopScene");
    }

    public void OpenSettings()
    {
        Click();
        settingsManager.SetUp();
    }

    public void QuitGame()
    {
        Click();
        Application.Quit();
    }

    public void Click()
    {
        mySource.clip = myClip;
        mySource.Play();
    }
}
