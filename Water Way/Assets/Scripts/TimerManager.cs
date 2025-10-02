using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField] Image countdownCircle;
    [SerializeField] int TimerValue;
    float multiplier=1;
    float TimerFloat;

    void Start()
    {
        TimerFloat = (float)TimerValue;
    }

    void Update()
    {
        TimerFloat -= Time.deltaTime * multiplier;
        countdownCircle.fillAmount = TimerFloat / TimerValue;
    }

    public void restartTimer()
    {
        TimerFloat = (float)TimerValue;
        multiplier += 0.05f;
    }
}

