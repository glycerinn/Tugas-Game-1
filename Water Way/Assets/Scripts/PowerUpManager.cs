using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class PowerUpManager : MonoBehaviour
{
    public int CoinMults;
    public int TimeMults;
    public float timeMultiplier = 1;
    public int coinMultiplier =1;
    public TextMeshProUGUI CoinMultiText;
    public TextMeshProUGUI TimeMultiText;
    public Timer timer;
    public CoinManager coin;

    void Start()
    {
        CoinMults = PlayerPrefs.GetInt("CoinMults");
        TimeMults = PlayerPrefs.GetInt("TimeMults");
        CoinMultiText.text = CoinMults.ToString();
        TimeMultiText.text = TimeMults.ToString();
    }

    // Update is called once per frame
    public void useTimeM()
    {
        TimeMults -= 1;
        PlayerPrefs.SetInt("TimeMults", TimeMults);
        StartCoroutine(TimeSlowSequence(1));
        TimeMultiText.text = TimeMults.ToString();
    }

    public void useCoinM()
    {
        CoinMults -= 1;
        PlayerPrefs.SetInt("CoinMults", CoinMults);
        StartCoroutine(AddCoinSequence(2));
        CoinMultiText.text = CoinMults.ToString();
    }

    IEnumerator TimeSlowSequence(float time)
    {
        timer.multiplier = 0;
        yield return new WaitForSeconds(15);
        timer.multiplier = time;
    }

    IEnumerator AddCoinSequence(int add)
    {
        coin.coinmultiplier = add;
        yield return new WaitForSeconds(15);
        coin.coinmultiplier = 1;
    }
}
