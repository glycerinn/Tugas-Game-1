using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CoinManager : MonoBehaviour
{
    public int CoinCount, TotalCoinCount;
    public TextMeshProUGUI CoinText;
    public int coinmultiplier = 1;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        CoinText.text = CoinCount.ToString();
    }

    public void AddCoin(int amount)
    {
        CoinCount += amount * coinmultiplier;
        CoinText.text = CoinCount.ToString();
        
    }

    public void AddtoTotal()
    {
        TotalCoinCount = PlayerPrefs.GetInt("TotalCoin", 0);
        TotalCoinCount += CoinCount;
        PlayerPrefs.SetInt("TotalCoin", TotalCoinCount);
        PlayerPrefs.Save();

        CoinCount = 0;
    }
}
