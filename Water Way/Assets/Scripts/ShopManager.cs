using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class ShopManager : MonoBehaviour
{
    int TotalCoins;
    public int CoinMults;
    public int TimeMults;
    public TextMeshProUGUI TotalCoinsText;
    public TextMeshProUGUI CoinMultiText;
    public TextMeshProUGUI TimeMultiText;



    void Start()
    {
        CoinMults = PlayerPrefs.GetInt("CoinMults", 0);
        TimeMults = PlayerPrefs.GetInt("TimeMults", 0);
        TotalCoins = PlayerPrefs.GetInt("TotalCoin", 0);
        TotalCoinsText.text = TotalCoins.ToString();
        CoinMultiText.text = CoinMults.ToString();
        TimeMultiText.text = TimeMults.ToString();
    }

    public void BacktoMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void buyCoinMulti()
    {
        if (TotalCoins >= 10)
        {
            TotalCoins -= 10;
            TotalCoinsText.text = TotalCoins.ToString();

            CoinMults += 1;
            CoinMultiText.text = CoinMults.ToString();

            PlayerPrefs.SetInt("TotalCoin", TotalCoins);
            PlayerPrefs.SetInt("CoinMults", CoinMults);
        }
    }

    public void buyTimeMulti()
    {
        if (TotalCoins >= 10)
        {
            TotalCoins -= 10;
            TotalCoinsText.text = TotalCoins.ToString();

            TimeMults += 1;
            TimeMultiText.text = TimeMults.ToString();

            PlayerPrefs.SetInt("TotalCoin", TotalCoins);
            PlayerPrefs.SetInt("TimeMults", TimeMults);
        }
    }
}
